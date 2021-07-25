using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Bunker":
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                break;
            case "Red":
                if (transform.tag == "Blue")
                {
                    Destroy(gameObject);
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }
                break;
            case "Blue":
                if (transform.tag == "Red")
                {
                    Destroy(gameObject);
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }
                break;
        }
    }
}
