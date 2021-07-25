using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMechController : BaseMechController
{
    private void Start() 
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator1 = track1.GetComponent<Animator>();
        animator2 = track2.GetComponent<Animator>();
        towerController = tower.GetComponent<TowerController>();
    }

    private void Update() 
    {
        towerController.Attack();
    }

    private void FixedUpdate() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float rotate = 0f;
        if (horizontal < 0) {
            rotate = rotateSpeed * Time.deltaTime;
        } else if (horizontal > 0) {
            rotate = -rotateSpeed * Time.deltaTime;
        }
        towerController.RotateTower(rotate, true);
        MovePosition(horizontal, vertical, rotate);
    }
}