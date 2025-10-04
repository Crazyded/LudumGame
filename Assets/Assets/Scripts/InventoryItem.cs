using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "The Harvester/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string description;
    public Sprite icon;
    // Другие свойства, например, можно ли комбинировать и т.д.
}