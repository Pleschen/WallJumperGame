using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSawRotator : MonoBehaviour {
    
    // Update is called once per frame
    void Update() {
        // Вращение диска
        gameObject.transform.Rotate(new Vector3(0, 0, -480) * Time.deltaTime); // Вращение метеора 
    }

}
