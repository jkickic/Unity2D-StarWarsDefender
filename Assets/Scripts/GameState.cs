using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour {
    [SerializeField] private int score = 0;

    void Awake() {
        SetupSingleton();
    }

    private void SetupSingleton() {
        int goCount = FindObjectsOfType(GetType()).Length;
        if (goCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    public void IncrementScore(int val) {
        score += val;
    }
    public void ResetScore() {
        score = 0;
    }

    public int GetScore() {
        return score;
    }
}