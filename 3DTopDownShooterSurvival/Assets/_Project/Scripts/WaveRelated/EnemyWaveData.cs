using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaveData  {

    public EnemyType type;
    public int MaxNo;
    public int currNo = 0;
    public float spawnRate;
    public float timeForNextSpawn = 0f;
	
}
