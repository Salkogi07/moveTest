using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<InventoryItem> inventoryItems;
    public Dictionary<Data, InventoryItem> inventoryDictionary;

    [Header("Inventory UI")]
    [SerializeField] private Transform inventorySlotParent;

    private UI_ItemSlot[] itemSlot;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        inventoryItems = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<Data, InventoryItem>();

        itemSlot = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();

        UpdateSlotUI(); // 정렬된 UI 업데이트
    }

    private void UpdateSlotUI()
    {
        // 아이템 슬롯을 업데이트하기 전에 리스트를 characterGrade를 기준으로 다시 정렬
        inventoryItems = inventoryItems.OrderBy(item => GetGradePriority(item.data.charaterGrade)).ToList();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            itemSlot[i].UpdateSlot(inventoryItems[i]);
        }
    }

    private int GetGradePriority(string grade)
    {
        switch (grade)
        {
            case "Common":
                return 0;
            case "Rare":
                return 1;
            case "Epic":
                return 2;
            case "Legendary":
                return 3;
            default:
                return 0; // 기본적으로 Common으로 처리
        }
    }

    public void AddItem(Data _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            inventoryItems.Add(newItem);
            inventoryDictionary.Add(_item, newItem);
        }

        UpdateSlotUI(); // 아이템이 추가된 후 UI 업데이트
    }

    public void RemoveItem(Data _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                inventoryItems.Remove(value);
                inventoryDictionary.Remove(_item);
            }
            else
                value.RemoveStack();
        }

        UpdateSlotUI(); // 아이템이 제거된 후 UI 업데이트
    }
}
