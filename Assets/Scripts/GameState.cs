using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    private int score = 0;

    void Start() {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    public void IncrementScore(int val) {
        score += val;
        scoreText.text = score.ToString();
    }

    public void SetHealthText(int health) {
        healthText.text = Mathf.Max(health, 0).ToString();
    }

}
