using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public enum CharacterGrade
{
    Common,
    Rare,
    Epic,
    Legendary
}

public class CharaterRate : MonoBehaviour
{
    public static CharaterRate instance;

    public UIDrowingScene ui;
    private CharacterDB characterDB;

    [Header("뽑기 결과 정보")]
    public CharaterRateUI resultOneRate;
    public Image resultOne;

    public CharaterRateUI[] resultTenRate;
    public Image resultTen;

    public string charaterGrade;
    public int charaterIndex;

    

    private void Start()
    {
        ui.UpdateJewel();
        characterDB = GetComponent<CharacterDB>();
    }

    public void StartOneGrade()
    {
        if (GameManager.Instance.Jewel >= 160)
        {
            GameManager.Instance.Jewel -= 160;
            ui.UpdateJewel();
            resultOne.gameObject.SetActive(true);
            CharacterGrade result = CheckCeiling();
            ResultOne(result);
            Debug.Log("뽑기 결과: " + result);
        }
        else return;
    }

    public void StartTenGrade()
    {
        if (GameManager.Instance.Jewel >= 1600)
        {
            GameManager.Instance.Jewel -= 1600;
            ui.UpdateJewel();
            resultTen.gameObject.SetActive(true);
            for (int i = 0; i < 10; i++)
            {
                CharacterGrade result = CheckCeiling();
                ResultTen(result, i);
                Debug.Log("뽑기 결과: " + result);
            }
        }
        else return;
    }

    private void ResultOne(CharacterGrade grade)
    {
        int Commonlength = characterDB.CharaterCommon.Length;
        int Rarelength = characterDB.CharaterRare.Length;
        int Epiclength = characterDB.CharaterEpic.Length;
        int Legendarylength = characterDB.CharaterLegendary.Length;
        if (resultOneRate != null)
        {
            if (grade == CharacterGrade.Common)
            {
                int randomValue = UnityEngine.Random.Range(1, Commonlength);
                resultOneRate.ResultRate("Common", randomValue);
            }
            else if (grade == CharacterGrade.Rare)
            {
                int randomValue = UnityEngine.Random.Range(1, Rarelength);
                resultOneRate.ResultRate("Rare", randomValue);
            }
            else if (grade == CharacterGrade.Epic)
            {
                int randomValue = UnityEngine.Random.Range(1, Epiclength);
                resultOneRate.ResultRate("Epic", randomValue);
            }
            else if (grade == CharacterGrade.Legendary)
            {
                int randomValue = UnityEngine.Random.Range(1, Legendarylength);
                resultOneRate.ResultRate("Legendary", randomValue);
            }
        }
    }

    private void ResultTen(CharacterGrade grade, int index)
    {
        int Commonlength = characterDB.CharaterCommon.Length;
        int Rarelength = characterDB.CharaterRare.Length;
        int Epiclength = characterDB.CharaterEpic.Length;
        int Legendarylength = characterDB.CharaterLegendary.Length;

        if (resultTenRate != null && index < resultTenRate.Length && resultTenRate[index] != null)
        {
            if (grade == CharacterGrade.Common)
            {
                int randomValue = UnityEngine.Random.Range(1, Commonlength);
                resultTenRate[index].ResultRate("Common", randomValue);
            }
            else if (grade == CharacterGrade.Rare)
            {
                int randomValue = UnityEngine.Random.Range(1, Rarelength);
                resultTenRate[index].ResultRate("Rare", randomValue);
            }
            else if (grade == CharacterGrade.Epic)
            {
                int randomValue = UnityEngine.Random.Range(1, Epiclength);
                resultTenRate[index].ResultRate("Epic", randomValue);
            }
            else if (grade == CharacterGrade.Legendary)
            {
                int randomValue = UnityEngine.Random.Range(1, Legendarylength);
                resultTenRate[index].ResultRate("Legendary", randomValue);
            }
        }
    }

    // 천장 시스템 확인 및 최고등급 캐릭터 보장
    private CharacterGrade CheckCeiling()
    {
        GameManager.Instance.legendaryPullCount++;
        GameManager.Instance.epicPullCount++;
        return LegendaryRate();
    }

    private CharacterGrade LegendaryRate()
    {
        //천장 체크
        if (GameManager.Instance.legendaryPullCount >= GameManager.Instance.legendaryCeilingStep2)
        {
            GameManager.Instance.legendaryPullCount = 0; // Reset pull count
            GameManager.Instance.legendaryRateUp = GameManager.Instance.legendaryRate;
            ui.UpdateRate();
            return CharacterGrade.Legendary;
        }
        else if (GameManager.Instance.legendaryCeilingStep1 <= GameManager.Instance.legendaryPullCount)
        {
            GameManager.Instance.legendaryRateUp += 6f;
        }

        float randomValue = UnityEngine.Random.Range(0f, 100f);

        if (randomValue < GameManager.Instance.legendaryRateUp)
        {
            GameManager.Instance.legendaryPullCount = 0; // Reset pull count
            GameManager.Instance.legendaryRateUp = GameManager.Instance.legendaryRate;
            ui.UpdateRate();
            return CharacterGrade.Legendary;
        }
        else
        {
            return EpicRate(ref randomValue);
        }
    }

    private CharacterGrade EpicRate(ref float randomValue)
    {
        if (GameManager.Instance.epicPullCount >= GameManager.Instance.epicCeilingStep2)
        {
            GameManager.Instance.epicPullCount = 0; // Reset pull count
            ui.UpdateRate();
            return CharacterGrade.Epic;
        }
        else if (GameManager.Instance.epicPullCount == GameManager.Instance.epicCeilingStep1)
        {
            randomValue = UnityEngine.Random.Range(0f, 100f);
            if (randomValue < GameManager.Instance.epicRateUp)
            {
                GameManager.Instance.epicPullCount = 0;
                ui.UpdateRate();
                return CharacterGrade.Epic;
            }
            else
            {
                randomValue = UnityEngine.Random.Range(0f, 100f);
                if (randomValue < GameManager.Instance.epicRate)
                {
                    GameManager.Instance.epicPullCount = 0;
                    ui.UpdateRate();
                    return CharacterGrade.Epic;
                }
                else
                {
                    return RareRate(out randomValue);
                }
            }
        }
        else
        {
            return RareRate(out randomValue);
        }
    }

    private CharacterGrade RareRate(out float randomValue)
    {
        randomValue = UnityEngine.Random.Range(0f, 100f);
        if (randomValue < GameManager.Instance.rareRate)
        {
            ui.UpdateRate();
            return CharacterGrade.Rare;
        }
        else
        {
            ui.UpdateRate();
            return CharacterGrade.Common;
        }
    }

    // 특정 최고등급 캐릭터 픽업 여부 확인
    public bool IsPickup(CharacterGrade grade)
    {
        if (grade == CharacterGrade.Legendary && UnityEngine.Random.Range(0f, 100f) < GameManager.Instance.pickupRate)
            return true;

        return false;
    }
}