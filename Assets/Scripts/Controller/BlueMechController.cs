using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMechController : BaseMechController
{
    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator1 = track1.GetComponent<Animator>();
        animator2 = track2.GetComponent<Animator>();
        towerController = tower.GetComponent<TowerController>();
        transform.Rotate(0, 0, 180);
    }

    // Update is called once per frame
    private void Update()
    {
        towerController.Attack();
    }

    private void FixedUpdate() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // float gunRotate = Input.GetAxis("GunRotate");

        float rotate = 0f;
        if (horizontal < 0) {
            rotate = rotateSpeed * Time.deltaTime;
        } else if (horizontal > 0) {
            rotate = -rotateSpeed * Time.deltaTime;
        }

        Debug.Log("roate：" + rotate);

        towerController.RotateTower(rotate, true);

        MovePosition(-horizontal, -vertical, rotate);    
    }
}
