using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 4f;
    private int waveNumber = 0;
    public bool scenaryPlaced = false;


    private void Update()
    {
        if (countdown <= 0f && scenaryPlaced)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        UIManager.Instance.timerText.text = "Proxima Horda: " + Mathf.Round(countdown).ToString();
    }

   IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, GameManager.Instance.scenaryGO.transform);
    }
}
