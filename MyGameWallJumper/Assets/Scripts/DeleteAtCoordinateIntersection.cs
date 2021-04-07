using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAtCoordinateIntersection : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
        if (gameObject.transform.position.y < -8f) { Destroy(gameObject); }
    }
}
