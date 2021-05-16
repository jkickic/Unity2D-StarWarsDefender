using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;
    private int waypointIndex = 0;
    List<Transform> path;

    // Start is called before the first frame update
    void Start()
    {
        path = waveConfig.GetWaypoints();
        transform.position = path[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= path.Count - 1)
        {
            float step = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, path[waypointIndex].position, step);

            if (((Vector2) transform.position) == ((Vector2) path[waypointIndex].position))
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }
}
