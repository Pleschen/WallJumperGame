using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadingData {
    // Загрузка данных в игру --------------------------
    
    // Возвращение общего количества коинов у игрока
    public static int ReturnTheNumberOfCoins() {
        if (PlayerPrefs.HasKey("Coins")) {
            return PlayerPrefs.GetInt("Coins");
        }
        else return 0;
    }
}
