using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI_ItemSlot : MonoBehaviour
{
    [SerializeField] private Image charaterGradeImage;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemText;

    public InventoryItem item;

    public void UpdateSlot(InventoryItem _newitem)
    {
        item = _newitem;

        itemImage.color = Color.white;

        if (item != null)
        {
            itemImage.sprite = item.data.image;
            if (item.data.charaterGrade == "Common")
                charaterGradeImage.color = new Color(1f, 1f, 1f);  // 흰색
            else if (item.data.charaterGrade == "Rare")
                charaterGradeImage.color = new Color(73f / 255f, 158f / 255f, 221f / 255f);
            else if (item.data.charaterGrade == "Epic")
                charaterGradeImage.color = new Color(118f / 255f, 73f / 255f, 173f / 255f);
            else if (item.data.charaterGrade == "Legendary")
                charaterGradeImage.color = new Color(255f / 255f, 235f / 255f, 0f / 255f);  // 노란색
            else
                Debug.LogError("알 수 없는 캐릭터 등급!");

            if (item.stackSize > 1)
            {
                itemText.text = item.stackSize.ToString();
            }
            else
            {
                itemText.text = "";
            }
        }
    }
}
