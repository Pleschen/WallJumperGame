using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class PauseButton : MonoBehaviour , IPointerDownHandler {
    public GameObject pauseMenuUI;

    public void OnPointerDown(PointerEventData eventData) {
        Pause();
    }

    void Pause() {
        GameSetups.GameIsPaused = true;
        pauseMenuUI.SetActive(true);        
    }
}