using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSawDirection : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        // Поворот в нужную сторону при появлении
        if (transform.position.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
        }
    }
}
