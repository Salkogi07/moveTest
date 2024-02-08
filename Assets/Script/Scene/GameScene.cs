using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public void OnclickButton()
    {
        Utils.LoadScene(SceneNames.GameScene);
    }
}
