using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    public void Restart() {
        SavingData.AddTheNumberOfCoins(GameSetups.Coins);              
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ExitToMenu() {
        SavingData.AddTheNumberOfCoins(GameSetups.Coins);                      
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);        
    }
}
