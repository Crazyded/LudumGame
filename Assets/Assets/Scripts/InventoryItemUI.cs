using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image iconImage;
    private InventoryItem myItem;
    public Button itemButton;

    public void SetItem(InventoryItem item)
    {
        myItem = item;
        iconImage.sprite = item.icon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.SetDescriptionText(myItem.itemName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.ClearDescriptionText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Selected item: {myItem.itemName}");
        // Здесь можно реализовать логику выбора предмета для использования
    }
}