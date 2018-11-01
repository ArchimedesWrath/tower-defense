using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownTimer;

    private float timeBetweenWaves = 5f;
    private float countDown = 2f;

    private int waveNumber = 1;
	
	void Update () {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountdownTimer.text = string.Format("{0:00.00}", countDown);
	}

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber - 1; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
