using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameObstaclesLogic : MonoBehaviour {
    // Поля
    [SerializeField] public GameObject Stone;       // Ссылка на камень
    [SerializeField] public GameObject CircularSaw; // Ссылка на оголенные провода
    [SerializeField] public GameObject OxygenTank;  // Ссылка на балон с кислородом
    public GameObject[] CoinGroup;

    private bool restZone;              // todo Зона отдыха
    private float[] y_CircularSaw;      // Координаты по Y для спавна пил

    // Start is called before the first frame update
    void Start() {
        y_CircularSaw = new float[2];
        y_CircularSaw[0] = 2.75f;
        y_CircularSaw[1] = -2.75f;
        StartCoroutine("CreatingStones");
        StartCoroutine("CreatingCircularSaw");
        StartCoroutine("CoinSpawner");
        StartCoroutine("OxygenTankSpawner");
    }

    // Создание камней    
    IEnumerator CreatingStones() {
        while (true) {
            if (GameSetups.GameIsPaused == false) {
                yield return new WaitForSeconds(Random.Range(4, 8));
                Instantiate(Stone, new Vector3(Random.Range(-2.325f, 2.325f), 13f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0);
        }
    }
    // Создание циркулирующих пил 
    IEnumerator CreatingCircularSaw() {
        while (true) {
            if (GameSetups.GameIsPaused == false) {
                yield return new WaitForSeconds(Random.Range(5, 9));
                Instantiate(CircularSaw, new Vector3(y_CircularSaw[Random.Range(0, y_CircularSaw.Length)], 13f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator CoinSpawner() {
        while (true) {
            if (GameSetups.GameIsPaused == false) {
                yield return new WaitForSeconds(Random.Range(3, 6));
                Instantiate(CoinGroup[Random.Range(0, CoinGroup.Length)], new Vector3(0, 13f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator OxygenTankSpawner() {
        while (true) {
            if (GameSetups.GameIsPaused == false) {
                yield return new WaitForSeconds(Random.Range(5, 7));
                Instantiate(OxygenTank, new Vector3(Random.Range(-2f,2f), 13f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0);
        }
    }
}
