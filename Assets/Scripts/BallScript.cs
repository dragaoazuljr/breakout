using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float initialSpeed = -20f;
    [SerializeField] private GameObject powerUp;

    public Vector3 lastSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector3(0, initialSpeed, 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        lastSpeed = rb.velocity;
    }

    void OnCollisionEnter(Collision collision) {
        float velocity = lastSpeed.magnitude;

        if (collision.gameObject.tag == "GreenBlock") {
            Vector3 greenBlockPosition = collision.gameObject.transform.position;
            Vector3 direction = Vector2.Reflect(lastSpeed.normalized, collision.contacts[0].normal);

            Destroy(collision.gameObject);

            int quantBalls = GameObject.FindGameObjectsWithTag("Ball").Length;

            if (quantBalls < 600) {
                spawnPowerUp(greenBlockPosition);
            }            

            rb.velocity = direction * velocity;
        } else if (collision.gameObject.tag == "Player") {
            Vector3 playerPosition = collision.gameObject.transform.position;
            Vector3 ballPosition = transform.position;

            float distance = (playerPosition.x - ballPosition.x) * -1;
            Vector3 direction = new Vector3(lastSpeed.x + distance, lastSpeed.y * -1, lastSpeed.z);

            rb.velocity = direction;
        } else {
            Vector3 direction = Vector2.Reflect(lastSpeed.normalized, collision.contacts[0].normal);
            rb.velocity = direction * velocity;
        }  
    }

    void spawnPowerUp(Vector3 position) {
        int random = Random.Range(0, 100);

        if(random < 10) {
            Instantiate(powerUp, position, Quaternion.identity);
        }
    }
}
