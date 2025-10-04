using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InteractableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string objectName;
    [TextArea]
    public string description;
    public InventoryItem requiredItem;
    public bool consumesItem = false;

    [Header("Action Settings")]
    public bool takesTime = false;
    public int timeCostHours = 0;
    public int timeCostMinutes = 0;

    [Header("Result Actions")]
    public InventoryItem givesItem;
    public string successMessage;
    public string useItemMessage;
    public string failMessage;

    private void Start()
    {
        // Автоматически добавляем Collider2D, если его нет
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Используем новый метод из GameManager
        GameManager.Instance.SetDescriptionText(objectName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Используем новый метод из GameManager
        GameManager.Instance.ClearDescriptionText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }

    public void Interact()
    {
        if (requiredItem != null)
        {
            if (InventoryManager.Instance.HasItem(requiredItem))
            {
                if (!string.IsNullOrEmpty(useItemMessage))
                    GameManager.Instance.SetDescriptionText(useItemMessage);

                if (consumesItem)
                {
                    InventoryManager.Instance.RemoveItem(requiredItem);
                }

                CompleteAction();
            }
            else
            {
                if (!string.IsNullOrEmpty(failMessage))
                    GameManager.Instance.SetDescriptionText(failMessage);
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(successMessage))
                GameManager.Instance.SetDescriptionText(successMessage);
            CompleteAction();
        }
    }

    private void CompleteAction()
    {
        if (takesTime)
        {
            GameManager.Instance.SpendTime(timeCostHours, timeCostMinutes);
        }

        if (givesItem != null)
        {
            InventoryManager.Instance.AddItem(givesItem);
        }
    }
}