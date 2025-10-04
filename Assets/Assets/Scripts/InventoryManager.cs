using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Transform inventoryUIParent; // ������������ ������ ��� UI ������ ���������
    public GameObject inventoryItemUIPrefab; // ������ ������ ��������

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

    // �������� ������� � ���������
    public void AddItem(InventoryItem item)
    {
        inventory.Add(item);
        UpdateInventoryUI();
        Debug.Log($"������� ��������: {item.itemName}");
    }

    // ������� ������� �� ���������
    public void RemoveItem(InventoryItem item)
    {
        inventory.Remove(item);
        UpdateInventoryUI();
    }

    // ���������, ���� �� ������� � ���������
    public bool HasItem(InventoryItem item)
    {
        return inventory.Contains(item);
    }

    // ���������� UI ���������
    private void UpdateInventoryUI()
    {
        // ������� ������� UI
        foreach (Transform child in inventoryUIParent)
        {
            Destroy(child.gameObject);
        }

        // ������� ����� ������
        foreach (InventoryItem item in inventory)
        {
            GameObject newItemUI = Instantiate(inventoryItemUIPrefab, inventoryUIParent);
            newItemUI.GetComponent<InventoryItemUI>().SetItem(item);
        }
    }
}
