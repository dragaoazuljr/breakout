using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string powerUpType;

    void Start()
    {
        powerUpType = Random.Range(0, 1) == 0 ? "Multiply" : "Add";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (powerUpType == "Multiply")
            {
                GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

                foreach (GameObject ball in balls)
                {
                    Vector3 ballPosition = ball.transform.position;

                    int quantNewBalls = balls.Length < 600 ? 3 : 0; 

                    if (quantNewBalls != 0) {
                        for (int i = 0; i < quantNewBalls; i++)
                        {
                            GameObject newBall = Instantiate(ball, ballPosition, Quaternion.identity);
                            Vector3 velocity = i == 0 ? new Vector3(0, -50, 0) : i > 1 ? new Vector3(-50, -50, 0) : new Vector3(50, -50, 0);
                            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                        }

                    }
                }
            }
            else
            {

            }

            Destroy(gameObject);
        }
    }
}
