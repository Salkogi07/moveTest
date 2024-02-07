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
        //Scenenames ���������� �Űº����� �޾ƿ� ��� Tostring() ó��
        SceneManager.LoadScene(sceneName.ToString());
    }
}
