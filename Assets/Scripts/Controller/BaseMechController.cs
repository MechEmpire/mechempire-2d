using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMechController : MonoBehaviour 
{
    public float rotateSpeed = 55.0f;
    
    public float moveSpeed = 3.0f;

    public GameObject track1;
    
    public GameObject track2;
    
    public GameObject tower;

    protected Rigidbody2D rigidbody2d;

    protected Animator animator1;

    protected Animator animator2;

    protected TowerController towerController;

    protected void TrackAnimation(float horizontal, float vertical) 
    { 
        if (Mathf.Approximately(horizontal, 0) && Mathf.Approximately(vertical, 0))
        {
            animator1.SetBool("Running", false);
            animator2.SetBool("Running", false);
        }
        else
        {
            animator1.SetBool("Running", true);
            animator2.SetBool("Running", true);
        }
    }

    protected void MovePosition(float horizontal, float vertical, float rotate) 
    {
        transform.Rotate(0, 0, rotate);
        transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * vertical * moveSpeed * Time.deltaTime, Space.World);
        TrackAnimation(horizontal, vertical);
    }
}