using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("SFX")] [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float deathVolume = 1f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] private float shootVolume = 1f;

    [Header("Enemy")] [SerializeField] private GameObject enemyLaser;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float laserSpeed = 1f;
    [SerializeField] private float health = 100;
    [SerializeField] private float shotCounter;
    [SerializeField] private float minShotsInterval = 0.2f;
    [SerializeField] private float maxShotsInterval = 3f;


    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        shotCounter = Random.Range(minShotsInterval, maxShotsInterval);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        CountdownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ProcessHit(collider);
    }

    private void CountdownAndShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0) {
            Fire();
            shotCounter = Random.Range(minShotsInterval, maxShotsInterval);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootVolume);
        }
    }

    private void Fire() {
        var laserInstance = Instantiate(enemyLaser, transform.position, Quaternion.identity);
        laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
    }

    private void ProcessHit(Collider2D collider) {
        DamageDealer dd = collider.GetComponent<DamageDealer>();
        if (dd is object) {
            health -= dd.GetDamage();
        }

        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
        var explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionInstance, 1);
        Destroy(gameObject);
    }
}