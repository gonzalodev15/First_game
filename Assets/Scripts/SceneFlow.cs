using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }
}

