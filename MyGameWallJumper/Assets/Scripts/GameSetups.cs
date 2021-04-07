using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public static partial class GameSetups {
    // Поля 
    // Игра    
    private static bool gameIsPaused = false;
    private static bool gameOver = false;
    // Время в игре
    private static float timeAccel = 5f;        // Ускорение времени: количество % каждые 100 метров
    private static float maxTimeScale = 1.6f;   // Максимальное значение Time.timeScale
    private static float timeScaleInGame;       // Время в игре

    // Камера
    private static float maxPlayerPosToAccelerationObjects = -0.7f; // Значение по Y, при пересечении которого объекты будут двигаться быстрее
    private static float minPlayerPosToDecelerationObjects = -3.5f; // Значение по Y, при пересечении которого объекты будут двигаться медленнее
    private static float objectsMovementSpeed;                      // Скорость смещения объектов
    private static float initialObjectsMovementSpeed = 3f;          // Заданная скорость смещения объектов

    // Игрок
    private static float distance = 0;              // Очки
    private static float oxygen = 0;                // Кислород
    private static float oxygenEndTime = 30;        // Время, за которое расходуется весь кислород в секундах
    private static int displayedScores;             // Отображаемые очки на панеле счета    
    private static int coins = 0;                   // Монеты
    private static float gravityScale = 0.24f;      // Значение гравитации игрока
    private static float jumpPower = 1100f;         // Сила прыжка
    private static float maxForceX = 2000f;         // Максимальная сила при прыжке по X
    private static float maxForceY = 2000f;         // Максимальная сила при прыжке по Y

    // Бонусы
    private static float oxygenTankAddition = 25;   // Прибавление кислорода от баллона с кислородом


    // Свойства полей
    public static float OxygenTankAddition {
        get { return oxygenTankAddition; }
        set { oxygenTankAddition = value; }
    }
    public static float OxygenEndTime {
        get { return oxygenEndTime; }
        set { oxygenEndTime = value; }
    }
    public static float Oxygen {
        get { return oxygen; }
        set { if (value < 100f) {
                oxygen = value;
            }
            else oxygen = 100f;
        }
    }
    public static bool GameOver {
        get { return gameOver; }
        set { gameOver = value; }
    }
    public static bool GameIsPaused {
        get { return gameIsPaused; }
        set { gameIsPaused = value; }
    }
    public static int DisplayedScores {
        get { return displayedScores; }
        set { displayedScores = value; }
    }
    public static float TimeAccel {
        get { return timeAccel; }
        set { timeAccel = value; }
    }
    public static float MaxTimeScale {
        get { return maxTimeScale; }
        set { maxTimeScale = value; }
    }
    public static float TimeScaleInGame {
        get { return timeScaleInGame; }
        set { timeScaleInGame = value; }
    }
    public static int Coins {
        get { return coins; }
        set { coins = value; }
    }
    public static float MaxPlayerPosToAccelerationObjects {
        get { return maxPlayerPosToAccelerationObjects; }
        set { maxPlayerPosToAccelerationObjects = value; }
    }
    public static float MinPlayerPosToDecelerationObjects {
        get { return minPlayerPosToDecelerationObjects; }
        set { minPlayerPosToDecelerationObjects = value; }
    }
    public static float ObjectsMovementSpeed {
        get { return objectsMovementSpeed; }
        set { objectsMovementSpeed = value; }
    }
    public static float InitialObjectsMovementSpeed {
        get { return initialObjectsMovementSpeed; }
        set { initialObjectsMovementSpeed = value; }
    }
    public static float JumpPower {
        get { return jumpPower; }
        set { jumpPower = value; }
    }
    public static float Distance {
        get { return distance; }
        set { distance = value; }
    }
    public static float MaxForceX {
        get { return maxForceX; }
        set { maxForceX = value; }
    }
    public static float MaxForceY {
        get { return maxForceY; }
        set { maxForceY = value; }
    }
    public static float GravityScale {
        get { return gravityScale; }
        set { gravityScale = value; }
    }   
}
