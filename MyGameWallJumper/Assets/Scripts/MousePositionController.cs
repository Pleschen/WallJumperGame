    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionController : MonoBehaviour
{

    private void Move() {        
            var newPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
            transform.position = newPosition;        
    }    

    // Update is called once per frame
    void Update()
    {
        Move();
    } 
}
