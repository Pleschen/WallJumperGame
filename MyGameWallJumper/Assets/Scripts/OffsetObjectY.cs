using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetObjectY : MonoBehaviour {
    private void FixedUpdate() {
        Offset();        
    }

    private void Offset() {
        transform.Translate(Vector3.down * GameSetups.ObjectsMovementSpeed * Time.deltaTime);
    }
}
