using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWaveConfig")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float spawnRandomness = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 3f;

    public GameObject EnemyPrefab { get => enemyPrefab; }
    public List<Transform> GetWaypoints() {
        List<Transform> wp = new List<Transform>();
        foreach (Transform t in pathPrefab.transform) {
            wp.Add(t);
        }
        return wp;
    }
    public float SpawnInterval { get => spawnInterval; }
    public float SpawnRandomMultiplier { get => Random.Range(-spawnRandomness, spawnRandomness); }
    public int NumberOfEnemies { get => numberOfEnemies; }
    public float MoveSpeed { get => moveSpeed;  }

}
