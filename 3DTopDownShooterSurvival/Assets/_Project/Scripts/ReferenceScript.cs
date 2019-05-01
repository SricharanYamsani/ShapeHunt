using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceScript : MonoBehaviour {

    public PlayerController PlayerOne;
    public Shop shop;
    public UIManager _UIManager;
    public WaveManager waveManager;
    public EnemySpawner enemySpawner;

	// Use this for initialization
	void Awake () {
       GameManager.Instance.SetScripts(this);
        //Invoke("Break", 1f);
    }
	
    public void Break()
    {
        GameManager.Instance.SetScripts(this);
    }
	
}
