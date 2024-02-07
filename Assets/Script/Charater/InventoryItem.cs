using System;

[Serializable]
public class InventoryItem
{
    public Data data;
    public int stackSize;

    public InventoryItem(Data _newItemData)
    {
        data = _newItemData;
        AddStack();
    }

    public void AddStack() => stackSize++;
    public void RemoveStack() => stackSize--;
}
