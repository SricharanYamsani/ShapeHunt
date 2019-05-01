using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public Text waveText;

    public WaveData[] waves;

    int currentWaveNumber = 0;

    int n_Waves;

    public float prevWaveTime = 0f, timeElapsed = 0f;

    private void Start()
    {
        n_Waves = waves.Length;

        //StartCoroutine(DisplayWaveNumber());
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        WaveData wave = waves[currentWaveNumber];

        foreach(EnemyWaveData ewave in wave.enemyWaveData)
        {
            if (Time.time > ewave.timeForNextSpawn + prevWaveTime)
            {
                if (ewave.currNo < ewave.MaxNo)
                {
                    ewave.timeForNextSpawn = Time.time + ewave.spawnRate;
                    ewave.currNo++;
                    EnemySpawner.Instance.Spawn(ewave.type);

                }
            }
        }


        foreach(EnemyWaveData ewave in wave.enemyWaveData)
        {
            if(ewave.currNo != ewave.MaxNo)
            {
                return;
            }

            prevWaveTime = timeElapsed;
            timeElapsed = 0f;
        }

        currentWaveNumber = currentWaveNumber == n_Waves - 1 ? 0 : currentWaveNumber + 1;

        //StartCoroutine(Breather());
       
        //StartCoroutine(DisplayWaveNumber());

    }

    IEnumerator DisplayWaveNumber()
    {
        waveText.gameObject.SetActive(true);

        waveText.text = "Wave " +(currentWaveNumber + 1);

        yield return new WaitForSeconds(2f);

        waveText.gameObject.SetActive(false);
    }

    IEnumerator Breather()
    {
        yield return new WaitForSeconds(9.0f);//Breather time

    }
}
