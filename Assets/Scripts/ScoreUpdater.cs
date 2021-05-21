using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private GameState gameState;

    void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
        gameState = FindObjectOfType<GameState>();
    }

    private void FixedUpdate() {
        textComponent.text = gameState.GetScore().ToString();
    }
}
