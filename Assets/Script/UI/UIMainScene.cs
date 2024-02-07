using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class UIMainScene : MonoBehaviour
{
    [Header("Resource UI")]
    public TextMeshProUGUI textJewel;
    private int Jewel;
    private int Gold;

    [Header("Inventory UI")]
    [SerializeField] private Transform inventorySlotParent;

    private UI_ItemSlot[] itemSlot;

    public List<InventoryItem> inventoryItems;
    public Dictionary<Data, InventoryItem> inventoryDictionary;

    // Start is called before the first frame update
    void Start()
    {
        Jewel = GameManager.Instance.Jewel;
        Gold = GameManager.Instance.Gold;

        textJewel.text = $"Jewel : {Jewel}";

        inventoryItems = Inventory.instance.inventoryItems;
        inventoryDictionary = Inventory.instance.inventoryDictionary;

        itemSlot = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
        UpdateSlotUI(); // 정렬된 UI 업데이트
    }


    public void OnclickCharater()
    {
        UpdateJewel();
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

    private void UpdateSlotUI()
    {
        // 아이템 슬롯을 업데이트하기 전에 리스트를 characterGrade를 기준으로 다시 정렬
        inventoryItems = inventoryItems.OrderBy(item => GetGradePriority(item.data.charaterGrade)).ToList();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            itemSlot[i].UpdateSlot(inventoryItems[i]);
        }
    }

    public void UpdateJewel()
    {
        Jewel = GameManager.Instance.Jewel;
        textJewel.text = $"Jewel : {Jewel}";
    }
}
