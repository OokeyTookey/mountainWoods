using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //LEVEL LOAAAADDDDIIIIIINNNNGGGG
    public GameObject PMenu;
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitRequest()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        PMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PMenu.SetActive(true);
        }
    }
}