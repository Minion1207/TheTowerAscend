using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void SceneSwitch(string scene)
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(scene);
    }
}