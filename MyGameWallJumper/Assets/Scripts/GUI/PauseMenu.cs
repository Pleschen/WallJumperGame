using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public void Resume() {
        pauseMenuUI.SetActive(false);
        GameSetups.GameIsPaused = false;
        Time.timeScale = GameSetups.TimeScaleInGame;        
    }

    public void ExitToMenu() {       
        GameSetups.GameIsPaused = false;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
