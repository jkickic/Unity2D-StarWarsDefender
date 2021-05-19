using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() {
        SetupSingleton();
    }

    private void SetupSingleton() {
        int mpCount = FindObjectsOfType<MusicPlayer>().Length;
        if (mpCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
