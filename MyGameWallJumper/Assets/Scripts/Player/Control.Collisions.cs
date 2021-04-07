using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Control : MonoBehaviour {
    //-------------------------------------------------------------
    // Триггеры
    private void OnTriggerEnter2D(Collider2D other) {

        // Coin
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            GameSetups.Coins += 1;
        }

        // Пила
        if (other.gameObject.CompareTag("CircularSaw")) {
            GameSetups.GameOver = true;
        }

        // Баллон с кислородом
        if (other.gameObject.CompareTag("OxygenTank")) {
            Destroy(other.gameObject);
            GameSetups.Oxygen += GameSetups.OxygenTankAddition;
        }
    }

    // В момент соприкосновение с коллайдером
    private void OnCollisionEnter2D(Collision2D collision) {
        // Wall
        if (collision.gameObject.CompareTag("Wall")) {
            oPlayer.gravityScale = 0;
            WallContact = true;
            StartCoroutine("PlayerAnimation");
        }
    }

    // Соприкосновение с коллайдером
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) { WallContact = true; }
        else { WallContact = false; }
    }

    // Отсоединение от коллайдера 
    private void OnCollisionExit2D(Collision2D collision) {
        //Стена
        if (collision.gameObject.CompareTag("Wall")) {
            oPlayer.gravityScale = GameSetups.GravityScale;
            WallContact = false;
            StartCoroutine("PlayerAnimation");
        }
    }
    //-------------------------------------------------------------
}
