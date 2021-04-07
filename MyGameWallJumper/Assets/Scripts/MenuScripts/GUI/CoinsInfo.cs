using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsInfo : MonoBehaviour {

    private void Start() {
        GetComponent<Text>().text = LoadingData.ReturnTheNumberOfCoins().ToString();
    }

}
