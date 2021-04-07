using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start() {
        // Задание постоянной скорости для пули
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().transform.right * bulletSpeed;
    }

    private void Update() {
        if (Mathf.Abs(transform.position.x) + Mathf.Abs(transform.position.y) > 8) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Stone") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


}
