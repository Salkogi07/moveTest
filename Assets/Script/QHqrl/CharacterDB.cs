using System;
using UnityEngine;

public class CharacterDB : MonoBehaviour
{
    [Header("ĳ���� DB")]
    public Data[] CharaterCommon;
    public Data[] CharaterRare;
    public Data[] CharaterEpic;
    public Data[] CharaterLegendary;

    public string[] GetCharacterInfo(string grade, int index)
    {
        string[] arr = new string[2];

        try
        {
            switch (grade)
            {
                case "Common":
                    if (index >= 0 && index < CharaterCommon.Length)
                    {
                        arr[0] = CharaterCommon[index].charaterName;
                        arr[1] = grade;
                    }
                    else
                    {
                        Debug.LogError("�ε����� ������ ������ϴ�");
                        return null;
                    }
                    break;
                case "Rare":
                    if (index >= 0 && index < CharaterRare.Length)
                    {
                        arr[0] = CharaterRare[index].charaterName;
                        arr[1] = grade;
                    }
                    else
                    {
                        Debug.LogError("�ε����� ������ ������ϴ�");
                        return null;
                    }
                    break;
                case "Epic":
                    if (index >= 0 && index < CharaterEpic.Length)
                    {
                        arr[0] = CharaterEpic[index].charaterName;
                        arr[1] = grade;
                    }
                    else
                    {
                        Debug.LogError("�ε����� ������ ������ϴ�");
                        return null;
                    }
                    break;
                case "Legendary":
                    if (index >= 0 && index < CharaterLegendary.Length)
                    {
                        arr[0] = CharaterLegendary[index].charaterName;
                        arr[1] = grade;
                    }
                    else
                    {
                        Debug.LogError("�ε����� ������ ������ϴ�");
                        return null;
                    }
                    break;
                default:
                    Debug.LogError("�߸��� ��");
                    return null;
            }

            return arr;
        }
        catch (Exception ex)
        {
            Debug.LogError($"���� �߻�: {ex.Message}");
            return null;
        }
    }
}
