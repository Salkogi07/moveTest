using UnityEngine;
using UnityEngine.UI;

public class Charater : MonoBehaviour
{
    public CharacterDB characterDB;
    public Text text;
    public Image image;

    public void ResultRate(string grade, int index)
    {
        string charaterGrade = characterDB.GetCharacterInfo(grade,index)[1];
        string charaterName = characterDB.GetCharacterInfo(grade, index)[0];

        if (charaterGrade == "Common")
            image.color = new Color(1f, 1f, 1f);  // 흰색
        else if (charaterGrade == "Rare")
            image.color = new Color(73f / 255f, 158f / 255f, 221f / 255f);
        else if (charaterGrade == "Epic")
            image.color = new Color(118f / 255f, 73f / 255f, 173f / 255f);
        else if (charaterGrade == "Legendary")
            image.color = new Color(255f / 255f, 235f / 255f, 0f / 255f);  // 노란색
        else
            Debug.LogError("알 수 없는 캐릭터 등급!");

        text.text = $"{charaterGrade}\n{charaterName}";
    }
}
