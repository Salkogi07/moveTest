using UnityEngine.SceneManagement;

public enum SceneNames { Logo = 0, TitleScene, MainScene, GameScene, DrowingScene }

public class Utils
{
    public static string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void LoadScene(string sceneName = "")
    {
        if (sceneName == "")
        {
            SceneManager.LoadScene(GetActiveScene());
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void LoadScene(SceneNames sceneName)
    {
        //Scenenames 열거형으로 매걔변수를 받아온 경우 Tostring() 처리
        SceneManager.LoadScene(sceneName.ToString());
    }
}
