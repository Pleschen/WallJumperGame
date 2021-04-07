using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrowerScript : MonoBehaviour
{

    [SerializeField] private LineRenderer Line;
    [SerializeField] private Transform MousePosition; // Позиция мыши
    [SerializeField] private Transform PlayerPosition; // Позиция игрока    

    [SerializeField] private GameObject StartMousePosition; 

    Vector3[] positions = new Vector3[2];

    // Start is called before the first frame update
    void Start() {
        Line = transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        DrawingJumpLine();        
    }


    // Процедура, ресующая линию от игрока к курсору при нажитии
    public void DrawingJumpLine() {
        if (Input.GetButtonDown("Fire1")) {
            StartMousePosition.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetButton("Fire1")) {
            Line.startWidth = 0.1f;
            Line.endWidth = 0.05f;

            //line.positionCount            
            positions[0] = new Vector3(MousePosition.position.x, MousePosition.position.y, 0.0f);            
            positions[1] = new Vector3(StartMousePosition.transform.position.x, StartMousePosition.transform.position.y, 0.0f);
            
            Line.positionCount = positions.Length;
            Line.SetPositions(positions);
        }
        if (Input.GetButtonUp("Fire1")) {
            Line.positionCount = 0;            
        }
    }    
}
