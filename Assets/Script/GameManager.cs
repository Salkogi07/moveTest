using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("게임 자원")]
    public int Jewel = 16000;
    public int Gold = 0;

    [Header("뽑기 카운트")]
    public int legendaryPullCount;
    public int epicPullCount;

    [Header("뽑기 확률")]
    public float rareRate = 40f;
    public float epicRate = 5.1f;
    public float epicRateUp = 56.1f;
    public float legendaryRate = 0.6f;
    public float legendaryRateUp = 0.6f;

    [Header("특정 최고등급 캐릭터 픽업 확률 설정")]
    public float pickupRate = 10f;

    [Header("천장 시스템 관련 변수")]
    public int legendaryCeilingStep1 = 74;
    public int legendaryCeilingStep2 = 90;

    public int epicCeilingStep1 = 9;
    public int epicCeilingStep2 = 10;

    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }
}


