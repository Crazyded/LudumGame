using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Transform inventoryUIParent; // Родительский объект для UI иконок инвентаря
    public GameObject inventoryItemUIPrefab; // Префаб иконки предмета

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Добавить предмет в инвентарь
    public void AddItem(InventoryItem item)
    {
        inventory.Add(item);
        UpdateInventoryUI();
        Debug.Log($"Предмет добавлен: {item.itemName}");
    }

    // Удалить предмет из инвентаря
    public void RemoveItem(InventoryItem item)
    {
        inventory.Remove(item);
        UpdateInventoryUI();
    }

    // Проверить, есть ли предмет в инвентаре
    public bool HasItem(InventoryItem item)
    {
        return inventory.Contains(item);
    }

    // Обновление UI инвентаря
    private void UpdateInventoryUI()
    {
        // Очищаем текущий UI
        foreach (Transform child in inventoryUIParent)
        {
            Destroy(child.gameObject);
        }

        // Создаем новые иконки
        foreach (InventoryItem item in inventory)
        {
            GameObject newItemUI = Instantiate(inventoryItemUIPrefab, inventoryUIParent);
            newItemUI.GetComponent<InventoryItemUI>().SetItem(item);
        }
    }
}
