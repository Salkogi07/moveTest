using System;
using UnityEngine;

public class CharacterDB : MonoBehaviour
{
    [Header("Ä³¸¯ÅÍ DB")]
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
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
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
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
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
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
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
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                default:
                    Debug.LogError("Àß¸øµÈ °ª");
                    return null;
            }

            return arr;
        }
        catch (Exception ex)
        {
            Debug.LogError($"¿À·ù ¹ß»ı: {ex.Message}");
            return null;
        }
    }

    public Sprite GetCharacterInfoImage(string grade, int index)
    {
        Sprite image;

        try
        {
            switch (grade)
            {
                case "Common":
                    if (index >= 0 && index < CharaterCommon.Length)
                    {
                        image = CharaterCommon[index].image;
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                case "Rare":
                    if (index >= 0 && index < CharaterRare.Length)
                    {
                        image = CharaterRare[index].image;
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                case "Epic":
                    if (index >= 0 && index < CharaterEpic.Length)
                    {
                        image = CharaterEpic[index].image;
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                case "Legendary":
                    if (index >= 0 && index < CharaterLegendary.Length)
                    {
                        image = CharaterLegendary[index].image;
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                default:
                    Debug.LogError("Àß¸øµÈ °ª");
                    return null;
            }

            return image;
        }
        catch (Exception ex)
        {
            Debug.LogError($"¿À·ù ¹ß»ı: {ex.Message}");
            return null;
        }
    }

    public Data GetCharaterData(string grade, int index)
    {
        Data data;

        try
        {
            switch (grade)
            {
                case "Common":
                    if (index >= 0 && index < CharaterCommon.Length)
                    {
                        data = CharaterCommon[index];
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                case "Rare":
                    if (index >= 0 && index < CharaterRare.Length)
                    {
                        data = CharaterRare[index];
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                case "Epic":
                    if (index >= 0 && index < CharaterEpic.Length)
                    {
                        data = CharaterEpic[index];
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                case "Legendary":
                    if (index >= 0 && index < CharaterLegendary.Length)
                    {
                        data = CharaterLegendary[index];
                    }
                    else
                    {
                        Debug.LogError("ÀÎµ¦½º°¡ ¹üÀ§¸¦ ¹ş¾î³µ½À´Ï´Ù");
                        return null;
                    }
                    break;
                default:
                    Debug.LogError("Àß¸øµÈ °ª");
                    return null;
            }

            return data;
        }
        catch (Exception ex)
        {
            Debug.LogError($"¿À·ù ¹ß»ı: {ex.Message}");
            return null;
        }
    }
}
