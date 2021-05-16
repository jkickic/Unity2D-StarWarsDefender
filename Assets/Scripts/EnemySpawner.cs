using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;
    [SerializeField] int startingWave = 0;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves() {
        for (int waveIndex = 0; waveIndex < waves.Count; waveIndex++) {
            yield return SpawnAllEnemies(waves[waveIndex]);
        }
    }

    private IEnumerator SpawnAllEnemies(WaveConfig currentWave)
    {
        for (int enemyIndex = 0; enemyIndex < currentWave.NumberOfEnemies; enemyIndex++) {
            var newEnemy = Instantiate(
                currentWave.EnemyPrefab,
                currentWave.GetWaypoints()[0].transform.position,
                Quaternion.identity
            );
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.SpawnInterval + currentWave.SpawnRandomMultiplier);
        }
    }



}
