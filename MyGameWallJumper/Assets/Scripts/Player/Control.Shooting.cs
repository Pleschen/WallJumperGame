using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Control : MonoBehaviour {

    // Поля
    [SerializeField] private GameObject o_bullet;

    private Vector3 _direction = new Vector3();
    private float _rotationZ;

    void Shooting() {
        _direction = StartMousePosition.transform.position - transform.position;       
        _rotationZ = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        spritePlayer.sprite = spriteShot;               
        Instantiate(o_bullet, transform.position, Quaternion.Euler(0, 0, _rotationZ));        
    }
}
