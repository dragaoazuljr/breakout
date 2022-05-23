using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
