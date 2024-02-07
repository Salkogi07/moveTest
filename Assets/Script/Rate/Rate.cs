using UnityEngine;
using UnityEngine.UI;
using System;

public enum CharacterGrade
{
    Common,
    Rare,
    Epic,
    Legendary
}

public class Rate : MonoBehaviour
{
    public Text text;


    [Header("뽑기 결과 정보")]
    public Charater resultOneRate;
    public Image resultOne;

    public Charater[] resultTenRate;
    public Image resultTen;

    public string charaterGrade;
    public int charaterIndex;

    [Header("뽑기 확률 설정")]
    public float rareRate = 40f;
    public float epicRate = 5.1f;
    public float epicRateUp = 56.1f;
    public float legendaryRate = 0.6f;
    public float legendaryRateUp = 0.6f;

    [Header("특정 최고등급 캐릭터 픽업 확률 설정")]
    public float pickupRate = 10f;

    [Header("천장 시스템 관련 변수")]
    private int legendaryPullCount = 0;
    public int legendaryCeilingStep1 = 74;
    public int legendaryCeilingStep2 = 90;

    private int epicPullCount = 0;
    public int epicCeilingStep1 = 9;
    public int epicCeilingStep2 = 10;

    public void StartOneGrade()
    {
        resultOne.gameObject.SetActive(true);
        CharacterGrade result = CheckCeiling();
        ResultOne(result);
        Debug.Log("뽑기 결과: " + result);
    }

    public void StartTenGrade()
    {
        resultTen.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            CharacterGrade result = CheckCeiling();
            ResultTen(result, i);
            Debug.Log("뽑기 결과: " + result);
        }
    }

    private void ResultOne(CharacterGrade grade)
    {
        if (resultOneRate != null)
        {
            if (grade == CharacterGrade.Common)
            {
                int randomValue = UnityEngine.Random.Range(1, 4);
                resultOneRate.ResultRate("Common", randomValue);
            }
            else if (grade == CharacterGrade.Rare)
            {
                int randomValue = UnityEngine.Random.Range(1, 5);
                resultOneRate.ResultRate("Rare", randomValue);
            }
            else if (grade == CharacterGrade.Epic)
            {
                int randomValue = UnityEngine.Random.Range(1, 5);
                resultOneRate.ResultRate("Epic", randomValue);
            }
            else if (grade == CharacterGrade.Legendary)
            {
                int randomValue = UnityEngine.Random.Range(1, 5);
                resultOneRate.ResultRate("Legendary", randomValue);
            }
        }
    }

    private void ResultTen(CharacterGrade grade, int index)
    {
        if (resultTenRate != null && index < resultTenRate.Length && resultTenRate[index] != null)
        {
            if (grade == CharacterGrade.Common)
            {
                int randomValue = UnityEngine.Random.Range(1, 4);
                resultTenRate[index].ResultRate("Common", randomValue);
            }
            else if (grade == CharacterGrade.Rare)
            {
                int randomValue = UnityEngine.Random.Range(1, 5);
                resultTenRate[index].ResultRate("Rare", randomValue);
            }
            else if (grade == CharacterGrade.Epic)
            {
                int randomValue = UnityEngine.Random.Range(1, 5);
                resultTenRate[index].ResultRate("Epic", randomValue);
            }
            else if (grade == CharacterGrade.Legendary)
            {
                int randomValue = UnityEngine.Random.Range(1, 5);
                resultTenRate[index].ResultRate("Legendary", randomValue);
            }
        }
    }

    // 천장 시스템 확인 및 최고등급 캐릭터 보장
    private CharacterGrade CheckCeiling()
    {
        legendaryPullCount++;
        epicPullCount++;
        return LegendaryRate();
    }

    private CharacterGrade LegendaryRate()
    {
        //천장 체크
        if (legendaryPullCount >= legendaryCeilingStep2)
        {
            legendaryPullCount = 0; // Reset pull count
            legendaryRateUp = legendaryRate;
            text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
            return CharacterGrade.Legendary;
        }
        else if (legendaryCeilingStep1 <= legendaryPullCount)
        {
            legendaryRateUp += 6f;
        }

        float randomValue = UnityEngine.Random.Range(0f, 100f);

        if (randomValue < legendaryRateUp)
        {
            legendaryPullCount = 0; // Reset pull count
            legendaryRateUp = legendaryRate;
            text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
            return CharacterGrade.Legendary;
        }
        else
        {
            return EpicRate(ref randomValue);
        }
    }

    private CharacterGrade EpicRate(ref float randomValue)
    {
        if (epicPullCount >= epicCeilingStep2)
        {
            epicPullCount = 0; // Reset pull count
            text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
            return CharacterGrade.Epic;
        }
        else if (epicPullCount == epicCeilingStep1)
        {
            randomValue = UnityEngine.Random.Range(0f, 100f);
            if (randomValue < epicRateUp)
            {
                epicPullCount = 0;
                text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
                return CharacterGrade.Epic;
            }
            else
            {
                randomValue = UnityEngine.Random.Range(0f, 100f);
                if (randomValue < epicRate)
                {
                    epicPullCount = 0;
                    text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
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
        if (randomValue < rareRate)
        {
            text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
            return CharacterGrade.Rare;
        }
        else
        {
            text.text = $"전설 스택: {legendaryPullCount}\n에픽 스택: {epicPullCount}";
            return CharacterGrade.Common;
        }
    }

    // 특정 최고등급 캐릭터 픽업 여부 확인
    public bool IsPickup(CharacterGrade grade)
    {
        if (grade == CharacterGrade.Legendary && UnityEngine.Random.Range(0f, 100f) < pickupRate)
            return true;

        return false;
    }
}