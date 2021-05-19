using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Player")] [SerializeField] float speedMultiplier = 0.35f;
    [SerializeField] float padding = 1f;
    [SerializeField] int hitPoints = 200;

    [Header("Projectile")] [SerializeField]
    float laserSpeed = 15f;

    [SerializeField] float projectileFiringInterval = 1f;
    [SerializeField] GameObject laser;

    [Header("Sound")] [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float deathVolume = 1f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] private float shootVolume = 1f;
    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] private float playerHitVolume = 1f;

    private Vector2 minVector;
    private Vector2 maxVector;
    private Coroutine fireCourutine;

    // Start is called before the first frame update
    void Start() {
        SetupMoveBoundries();
    }

    // Update is called once per frame
    void Update() {
        if (hitPoints > 0) {
            MovePlayer();
            ShootLasers();
        }
    }


    private void SetupMoveBoundries() {
        var cam = Camera.main;
        maxVector = cam.ViewportToWorldPoint(new Vector3(1, 0.6f, 0));
        minVector = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
    }

    private void MovePlayer() {
        var multiplier = Time.deltaTime * speedMultiplier;
        var deltaX = Input.GetAxis("Horizontal") * multiplier;
        var deltaY = Input.GetAxis("Vertical") * multiplier;

        var newX = transform.position.x + deltaX;
        var newY = transform.position.y + deltaY;

        var clampedX = Mathf.Clamp(newX, minVector.x + padding, maxVector.x - padding);
        var clampedY = Mathf.Clamp(newY, minVector.y + padding, maxVector.y - padding);

        transform.position = new Vector2(clampedX, clampedY);
    }

    private void ShootLasers() {
        if (Input.GetButtonDown("Fire1")) {
            fireCourutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(fireCourutine);
        }
    }

    private IEnumerator FireContinuously() {
        while (true) {
            var laserInstance = Instantiate(laser, transform.position, Quaternion.identity);
            laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootVolume);
            yield return new WaitForSeconds(projectileFiringInterval);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ProcessHit(collider);
    }

    private void ProcessHit(Collider2D collider) {
        DamageDealer dd = collider.GetComponent<DamageDealer>();
        if (dd is object) {
            hitPoints -= dd.GetDamage();
            AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, deathVolume);
        }

        if (hitPoints <= 0) {
            Die();
        }
    }

    private void Die() {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
        Destroy(gameObject);
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }
}