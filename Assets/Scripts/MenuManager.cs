using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Debug.Log("LoadGame");
    }
}