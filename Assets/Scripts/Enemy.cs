using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private float laserSpeed = 1f;
    [SerializeField] private float health = 100;
    
    [SerializeField] private float shotCounter;
    
    [SerializeField] private float minShotsInterval = 0.2f; 
    [SerializeField] private float maxShotsInterval = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minShotsInterval, maxShotsInterval);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownAndShoot();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessHit(collider);
    }

    private void CountdownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0) {
            Fire();
            shotCounter = Random.Range(minShotsInterval, maxShotsInterval);
        }
    }

    private void Fire() {
        var laserInstance = Instantiate(enemyLaser, (Vector2) transform.position, Quaternion.identity);
        laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }

    private void ProcessHit(Collider2D collider)
    {
        DamageDealer dd = collider.GetComponent<DamageDealer>();
        if (dd is object)
        {
            health -= dd.GetDamage();
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
