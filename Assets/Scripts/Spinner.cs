using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spinner : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private float randomizer = 180f;
    [SerializeField] private float realSpeed;
    void Start() {
        var backwards = Random.Range(0, 2) == 1 ? -1 : 1;
        realSpeed = backwards * (rotationSpeed + Random.Range(-randomizer, randomizer));
    }

    void Update() {
        transform.Rotate(new Vector3(0, 0, realSpeed) * Time.deltaTime);
    }
}
