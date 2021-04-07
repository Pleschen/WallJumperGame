using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Control : MonoBehaviour {

    // Поля    
    [SerializeField] private Rigidbody2D oPlayer;       
    [SerializeField] private Transform MousePosition;
    [SerializeField] private GameObject StartMousePosition;    
    [SerializeField] private SpriteRenderer spritePlayer;
    [SerializeField] public  Transform scalePlayer;

    Vector2 vecJump;  
    Vector3 scalePlayerSpriteL;
    Vector3 scalePlayerSpriteR;
   
    private bool WallContact = false;       // Контакт со стеной

    // Спрайты
    [SerializeField] public Sprite spriteOnWall;
    [SerializeField] public Sprite spriteJump;
    [SerializeField] public Sprite spriteShot;

    void Start() {   
        vecJump = new Vector2();
        scalePlayerSpriteL = new Vector3(0.75f, 0.85f, 0.75f);
        scalePlayerSpriteR = new Vector3(-0.75f, 0.85f, 0.75f);
        StartCoroutine("Jump");
    }

    // Прыжок
    private IEnumerator Jump() {        
        while (true) {
            if (Input.GetButtonDown("Fire1") && GameSetups.GameIsPaused == false) {
                StartMousePosition.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Проверка, не отпущена ли кнопка во время задержки в 80 милисек.
                for (int i = 0; i < 8; i++) {
                    yield return new WaitForSeconds(0.01f);
                    if (Input.GetButton("Fire1") == false) goto ResultJump;
                }
                ResultJump:
                vecJump = (MousePosition.position - StartMousePosition.transform.position);                
                if (Mathf.Abs(vecJump.x) + Mathf.Abs(vecJump.y) < 0.2f * Time.timeScale) { Shooting(); }
                else {                    
                    if (WallContact == true) {
                        vecJump.Normalize();
                        MathJump(); // Расчет силы прыжка   
                                    // Прыжок, и ограничение прыжка в сторону стены
                        if (vecJump.x >  2 && transform.position.x < 0) { oPlayer.AddForce(vecJump); }
                        if (vecJump.x < -2 && transform.position.x > 0) { oPlayer.AddForce(vecJump); }
                    }
                    else { 
                        yield return new WaitForSeconds(0.06f);
                        if (WallContact == true) {
                            vecJump.Normalize();
                            MathJump(); // Расчет силы прыжка   
                            // Прыжок, и ограничение прыжка в сторону стены
                            if (vecJump.x >  2 && transform.position.x < 0) { oPlayer.AddForce(vecJump); }
                            if (vecJump.x < -2 && transform.position.x > 0) { oPlayer.AddForce(vecJump); }
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0f);
        }
    }

    // Расчет силы прыжка
    private void MathJump() {
        float a; // Коэф, который выведен из формулы F = sqrt((ax)^2+(ay)^2)
        a = GameSetups.JumpPower / Mathf.Sqrt(Mathf.Pow(vecJump.x, 2) + Mathf.Pow(vecJump.y, 2));          
        vecJump *= Mathf.Abs(a);        
    }
    //-------------------------------------------------------------

    // Анимация
    private IEnumerator PlayerAnimation() {
        if (WallContact == true) {
            if (transform.position.x < 0) {
                yield return new WaitForSeconds(0.07f);
                spritePlayer.sprite = spriteOnWall;
                scalePlayer.transform.localScale = scalePlayerSpriteL;
            }
            else {
                yield return new WaitForSeconds(0.07f);
                spritePlayer.sprite = spriteOnWall;
                scalePlayer.transform.localScale = scalePlayerSpriteR;
            }
        }
        else {
            if (transform.position.x < 0) { spritePlayer.sprite = spriteJump; }
                else { spritePlayer.sprite = spriteJump; }
            yield return new WaitForSeconds(0f);
        }
    }
}
