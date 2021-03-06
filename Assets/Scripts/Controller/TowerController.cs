using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float rotateSpeed = 55.0f;
    public Vector2 towerDirection { get { return direction; } }
    public GameObject bullectPrefab;
    public AudioClip fireAudio;
    protected Vector2 direction = new Vector2(1, 0);

    public void RotateTower(float gunRotate, bool limit)
    {
        if (limit)
        {
            if (gunRotate < 0 && (transform.localEulerAngles.z < 60.0f ||
                    transform.localEulerAngles.z > 295.0f))
            {
                transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else if (gunRotate > 0 && (transform.localEulerAngles.z < 65.0f ||
                transform.localEulerAngles.z > 300.0f))
            {
                transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (gunRotate < 0)
            {
                transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else if (gunRotate > 0)
            {
                transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            }
        }

        float rad = -1.0f * transform.eulerAngles.z * Mathf.Deg2Rad;
        float x = Mathf.Sin(rad);
        float y = Mathf.Cos(rad);
        direction.Set(x, y);
        direction.Normalize();
    }

    public abstract void Launch(string launcher);

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullectPrefab, transform.position + new Vector3(direction.x * 5, direction.y* 5, 0), Quaternion.Euler(transform.eulerAngles));
            AudioSource.PlayClipAtPoint(fireAudio, transform.position);
        }
    }
}
