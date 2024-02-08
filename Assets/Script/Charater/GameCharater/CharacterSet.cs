using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSet : MonoBehaviour
{
    public Image SetCharacterUI1;
    public Image SetCharacterUI2;
    public Image SetCharacterUI3;
    public Image SetCharacterUI4;

    public int currentPlayNum = 0;
            
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            InputButton1();
        else if (Input.GetKeyDown(KeyCode.W))
            InputButton2();
        else if (Input.GetKeyDown(KeyCode.E))
            InputButton3();
        else if (Input.GetKeyDown(KeyCode.R))
            InputButton4();
    }

    public void InputButton1()
    {
        currentPlayNum = 1;
        SetCharacterUI1.gameObject.SetActive(true);
        SetCharacterUI2.gameObject.SetActive(false);
        SetCharacterUI3.gameObject.SetActive(false);
        SetCharacterUI4.gameObject.SetActive(false);
    }
    public void InputButton2()
    {
        currentPlayNum = 2;
        SetCharacterUI1.gameObject.SetActive(false);
        SetCharacterUI2.gameObject.SetActive(true);
        SetCharacterUI3.gameObject.SetActive(false);
        SetCharacterUI4.gameObject.SetActive(false);
    }
    public void InputButton3()
    {
        currentPlayNum = 3;
        SetCharacterUI1.gameObject.SetActive(false);
        SetCharacterUI2.gameObject.SetActive(false);
        SetCharacterUI3.gameObject.SetActive(true);
        SetCharacterUI4.gameObject.SetActive(false);
    }
    public void InputButton4()
    {
        currentPlayNum = 4;
        SetCharacterUI1.gameObject.SetActive(false);
        SetCharacterUI2.gameObject.SetActive(false);
        SetCharacterUI3.gameObject.SetActive(false);
        SetCharacterUI4.gameObject.SetActive(true);
    }
}
