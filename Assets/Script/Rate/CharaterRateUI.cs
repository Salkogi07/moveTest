using UnityEngine;
using UnityEngine.UI;

public class CharaterRateUI : MonoBehaviour
{
    [SerializeField] private CharacterDB characterDB;
    [SerializeField] private Image charaterEffect;
    [SerializeField] private Text text;
    [SerializeField] private Image charater;

    public void ResultRate(string grade, int index)
    {
        string charaterGrade = characterDB.GetCharacterInfo(grade,index)[1];
        string charaterName = characterDB.GetCharacterInfo(grade, index)[0];
        Sprite charaterImage = characterDB.GetCharacterInfoImage(grade, index);
        CharaterData data = characterDB.GetCharaterData(grade, index);

        if (charaterGrade == "Common")
            charaterEffect.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);  // 흰색
        else if (charaterGrade == "Rare")
            charaterEffect.color = new Color(73f / 255f, 158f / 255f, 221f / 255f);
        else if (charaterGrade == "Epic")
            charaterEffect.color = new Color(118f / 255f, 73f / 255f, 173f / 255f);
        else if (charaterGrade == "Legendary")
            charaterEffect.color = new Color(255f / 255f, 235f / 255f, 0f / 255f);  // 노란색
        else
            Debug.LogError("알 수 없는 캐릭터 등급!");

        charater.sprite = charaterImage;
        Inventory.instance.AddItem(data);

        text.text = $"{charaterName}";
    }
}
