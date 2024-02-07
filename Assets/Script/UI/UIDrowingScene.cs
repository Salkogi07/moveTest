using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDrowingScene : MonoBehaviour
{
    public TextMeshProUGUI textJewel;
    public Text textRate;

    [Header("게임 자원")]
    private int Jewel;
    private int Gold;

    [Header("뽑기 카운트")]
    private int legendaryPullCount;
    private int epicPullCount;

    private float legendaryRateUp;
    private float epicRate;
    private float epicRateUp;

    // Start is called before the first frame update
    void Start()
    {
        UpdateJewel();
        UpdateRate();
    }

    public void UpdateJewel()
    {
        Jewel = GameManager.Instance.Jewel;
        textJewel.text = $"Jewel : {Jewel}";
    }

    public void UpdateRate()
    {
        legendaryPullCount = GameManager.Instance.legendaryPullCount;
        epicPullCount = GameManager.Instance.epicPullCount;

        legendaryRateUp = GameManager.Instance.legendaryRateUp;
        epicRate = GameManager.Instance.epicRate;
        epicRateUp = GameManager.Instance.epicRateUp;

        float rate = 0f;

        if(epicPullCount == GameManager.Instance.epicCeilingStep2)
        {
            rate = 100f;
        }
        else if(epicPullCount >= GameManager.Instance.epicCeilingStep1)
        {
            rate = epicRateUp;
        }
        else
        {
            rate = epicRate;
        }

        textRate.text = $"전설 스택: {legendaryPullCount}({legendaryRateUp}%)\n에픽 스택: {epicPullCount}({rate}%)";
    }
}
