using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("GameOver"));
    }

    public IEnumerator WaitAndLoad(string sceneName) {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
