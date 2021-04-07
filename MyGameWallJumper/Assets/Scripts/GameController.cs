using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameController : MonoBehaviour {

    // Поля
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject menuGameOver;

    [SerializeField] private Text ScorePanel;
    [SerializeField] private Text CoinPanel;

    [SerializeField] private Text DistanceInGameOverMenu;
    [SerializeField] private Text CoinsInGameOverMenu;

    [SerializeField] private Slider OxygenBar;

    // Инициализация игры
    void Start() {
        // Инициализация полей
        GameSetups.Distance = 0;
        GameSetups.Coins = 0;
        GameSetups.DisplayedScores = 0;

        DistanceInGameOverMenu.text = "0" + "<size=100><color=red>m</color></size>";
        CoinsInGameOverMenu.text = "0" + " <size=115><color=white>×</color></size>";

        GameSetups.GameOver = false;
        GameSetups.GameIsPaused = false;
        GameSetups.ObjectsMovementSpeed = GameSetups.InitialObjectsMovementSpeed;
        Time.timeScale = 1;

        GameSetups.Oxygen = 100;

        /* Запуск корутин */
        StartCoroutine("GameEvents");
    }

    private void Update() {
        if (GameSetups.GameIsPaused == false) {
            CountingScore();
            MoveObjects();             // Вызов метода MoveObjects()
            if (Player.transform.position.y < -6.8) { GameSetups.GameOver = true; } // Игрок упал            
            if (GameSetups.Oxygen < 0) { GameSetups.GameOver = true; }      // Кислород закончился Конец игры
            if (GameSetups.GameOver == true) { GameOver(); }
        } else {
            Time.timeScale = 0;
        }
    }
    private void FixedUpdate() {
        if (GameSetups.GameIsPaused == false) {
            DecreaseOxygen();    // Уменьшение кислорода
        }
    }

    // Корутина, запускающая основные методы игры
    private IEnumerator GameEvents() {
        while (true) {
            if (GameSetups.GameIsPaused == false) {     
                

                AccelerateTheGame(); // Ускорение игры                
                CoinsAdd();


                yield return new WaitForSeconds(0.1f); 
            }
                yield return new WaitForSeconds(0); 
        }        
    }


    // Ускорение или замедление смещения камеры при пересечении игроком заданного Y (смещение всех объектов вниз)
    private void MoveObjects() {
        // Ускорение
        if (Player.transform.position.y > GameSetups.MaxPlayerPosToAccelerationObjects) {
            GameSetups.ObjectsMovementSpeed = GameSetups.InitialObjectsMovementSpeed * 1.4f *
                (Player.transform.position.y - GameSetups.MaxPlayerPosToAccelerationObjects + 0.3f);
            /* Коэфф 0.3 делает плавным возвращение к стандартной скорости,
            но она падает ниже стандартной по этому применяем проверку*/
            if (GameSetups.ObjectsMovementSpeed < GameSetups.InitialObjectsMovementSpeed) { GameSetups.ObjectsMovementSpeed = GameSetups.InitialObjectsMovementSpeed; }
        }
        else {
            // Замедление
            if (Player.transform.position.y < GameSetups.MinPlayerPosToDecelerationObjects) {
                GameSetups.ObjectsMovementSpeed = GameSetups.InitialObjectsMovementSpeed / 1.4f;
            }
            // Нормализация
            else {
                GameSetups.ObjectsMovementSpeed = GameSetups.InitialObjectsMovementSpeed;
            }
        }
    }

    // Подсчет очков
    private void CountingScore() {
        GameSetups.Distance += GameSetups.ObjectsMovementSpeed * 1.5f * Time.deltaTime;
        GameSetups.DisplayedScores = (int)GameSetups.Distance;
        ScorePanel.text = GameSetups.DisplayedScores.ToString() + "<size=100><color=red>m</color></size>";
    }

    // Ускорение времени в игре
    private void AccelerateTheGame() {
        if (Time.timeScale < GameSetups.MaxTimeScale && GameSetups.GameIsPaused == false) {
            Time.timeScale = 1 + (GameSetups.Distance * GameSetups.TimeAccel / 10000f);            
            GameSetups.TimeScaleInGame = Time.timeScale;
        }
    }
    // Добавление коинов
    public void CoinsAdd() {        
        CoinPanel.text = GameSetups.Coins.ToString() + " <size=115><color=white>×</color></size>";
    }

    // Конец игры 
    public void GameOver() {
        GameSetups.GameIsPaused = true;        
        menuGameOver.SetActive(true);
        CoinsInGameOverMenu.text = GameSetups.Coins.ToString();
        DistanceInGameOverMenu.text = ((int)GameSetups.Distance).ToString()
            + "<size=100><color=red>m</color></size>";
        Time.timeScale = 0;
    }
    // Уменьшение кислорода
    private void DecreaseOxygen() {
        GameSetups.Oxygen -= (100f / GameSetups.OxygenEndTime) * Time.deltaTime;
        OxygenBar.value = GameSetups.Oxygen / 100; // Устанавливаем значение бару        
    }
}
