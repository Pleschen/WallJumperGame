using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavingData {
    // Сохранение информации в файл----------------------


    // Сохранение количества коинов
    public static void AddTheNumberOfCoins(int coins) {
        int a;
        if (PlayerPrefs.HasKey("Coins")) {
            a = PlayerPrefs.GetInt("Coins");
        }
        else a = 0;
        PlayerPrefs.SetInt("Coins", a + coins);
    }
}
