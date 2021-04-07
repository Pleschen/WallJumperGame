using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateWall : MonoBehaviour
{
    private Vector3 vec3;
    private Vector3 vec3_dif;

    private void Start() {
        vec3 = new Vector3(0, 14.0145f, 0f);
        vec3_dif = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        // Перемещение стены вначало при пересечении координат        
        if (transform.position.y < -14.0145f) {
            vec3_dif.y = -14.0145f - transform.position.y;
            transform.position = vec3 - vec3_dif;
        }
    }
}
