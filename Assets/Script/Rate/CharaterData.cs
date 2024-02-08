using UnityEngine;

[CreateAssetMenu(menuName = "Scciptable/Data", fileName = "Data")]
public class CharaterData : ScriptableObject
{
    public Sprite image;
    public GameObject MainMovecharater;
    public string charaterName;
    public string charaterGrade;
    public int charaterIndex;
}
