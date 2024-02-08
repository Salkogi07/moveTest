using System;

[Serializable]
public class InventoryItem
{
    public CharaterData data;
    public int stackSize;

    public InventoryItem(CharaterData _newItemData)
    {
        data = _newItemData;
        AddStack();
    }

    public void AddStack() => stackSize++;
    public void RemoveStack() => stackSize--;
}
