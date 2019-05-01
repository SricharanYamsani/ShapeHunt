using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    //public SceneManager Instance;
    public GameObject GameModePanel;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        //else
        //{
        //    if (Instance != this)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
        ////DontDestroyOnLoad(this.gameObject);
    }

    public void OnClickPlay()
    {
        GameModePanel.SetActive(true);
    }

    public void OnClickWave()
    {
        GameManager.Instance.SetGameMode(GameMode.WAVE);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnClickEndless()
    {
        GameManager.Instance.SetGameMode(GameMode.ENDLESS);

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickReplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
