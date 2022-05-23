using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Vector3 movement = Vector3.zero;

    private int wallHitted = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && wallHitted != 1)
        {
            if (speed < 20) {
                movement.x+=speed;
            }
        } else if (Input.GetAxis("Horizontal") < 0 && wallHitted != -1)
        {
            if (speed < 20) {
                movement.x-=speed;
            }
        } else {
            movement.x = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallHitted = rb.position.x > 0 ? 1 : -1;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallHitted = 0;
        }
    }
}
