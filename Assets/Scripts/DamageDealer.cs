using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] int damage = 100;

    public int GetDamage() {
        return damage;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Hit(collision);
    }

    public void Hit(Collider2D collision) {
        if (GetComponent<Enemy>() != null) {
            return;
        }
        Destroy(gameObject);
    }
}