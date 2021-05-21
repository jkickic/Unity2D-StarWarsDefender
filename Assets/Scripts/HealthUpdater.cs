using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUpdater : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
    }
    public void SetHealthText(int hitPoints) {
        textComponent.text = Mathf.Max(hitPoints, 0).ToString();
    }
}
