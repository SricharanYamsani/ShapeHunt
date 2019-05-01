using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    WAVE,
    ENDLESS
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    GameMode gameMode;

    public PlayerController PlayerOne;

    public Shop shop;

    public int score ;

    public UIManager _UIManager;

    public WaveManager waveManager;

    public EnemySpawner enemySpawner;

    

    void Awake () {

		if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);

       //Init();

        //SetGameMode(GameMode.ENDLESS);
	}


    public void OnLevelWasLoaded(int level)
    {
        Debug.Log("INDEX " + level);
        //Init();

        //if(level == 1)
          //  SetScript
    }



    public void SetScripts(ReferenceScript RefScript)
    {
        PlayerOne = RefScript.PlayerOne;
        shop = RefScript.shop;
        _UIManager = RefScript._UIManager;
        waveManager = RefScript.waveManager;
        enemySpawner = RefScript.enemySpawner;

        if (gameMode == GameMode.ENDLESS)
            waveManager.gameObject.SetActive(false);
    }



    void Init()
    {
        
        PlayerOne = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if(PlayerOne == null)
        {
            Debug.LogWarning("PlayerController Component not found");
        }

        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
        shop.SetShop();

        if (shop == null)
        {
            Debug.LogWarning("Shop Component not found");
        }

        _UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        if (_UIManager == null)
        {
            Debug.LogWarning("UIManager Component not found");
        }

        waveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();

        if (waveManager == null)
        {
            Debug.LogWarning("WaveManager Component not found");
        }

        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();

        if (enemySpawner == null)
        {
            Debug.LogWarning("EnemySpawner Component not found");
        }
    }

    public void OnPlayerDeath()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void UpdateScore(int amount)
    {
        score += amount;

        _UIManager.UpdateScoreText(score);
    }

	// Update is called once per frame
	void Update () {
       // GetInputs();
	}

    public void SetGameMode(GameMode gm)
    {
        gameMode = gm;

        if (gm != GameMode.WAVE && waveManager!=null)
            waveManager.gameObject.SetActive(false);

        Debug.Log(gameMode);
    }

    public GameMode GetGameMode()
    {
        return gameMode;
    }
   
}
