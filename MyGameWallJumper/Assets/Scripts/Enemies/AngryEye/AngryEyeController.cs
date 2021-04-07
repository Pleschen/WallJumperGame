using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEyeController : MonoBehaviour {

    Enemy AngryEye;

    void Start() {
        AngryEye = new Enemy();
        AngryEye.hitPoints = 1;
        AngryEye.moneyForKilling = 2;

        AngryEye.canFly = true;
        AngryEye.canAttack = true;
        AngryEye.canCrawlOnWalls = false;
    }

}
