using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BareWiresRotator : MonoBehaviour {
    private void Start() {
        if (transform.position.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
        }
    }
}
