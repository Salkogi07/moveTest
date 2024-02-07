using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("���� �ڿ�")]
    public int Jewel = 16000;
    public int Gold = 0;

    [Header("�̱� ī��Ʈ")]
    public int legendaryPullCount;
    public int epicPullCount;

    [Header("�̱� Ȯ��")]
    public float rareRate = 40f;
    public float epicRate = 5.1f;
    public float epicRateUp = 56.1f;
    public float legendaryRate = 0.6f;
    public float legendaryRateUp = 0.6f;

    [Header("Ư�� �ְ��� ĳ���� �Ⱦ� Ȯ�� ����")]
    public float pickupRate = 10f;

    [Header("õ�� �ý��� ���� ����")]
    public int legendaryCeilingStep1 = 74;
    public int legendaryCeilingStep2 = 90;

    public int epicCeilingStep1 = 9;
    public int epicCeilingStep2 = 10;

    // �̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
    private static GameManager _instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }
}


