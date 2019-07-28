using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public Vector3 checkpoint;
    void Start()
    {
        checkpoint = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            checkpoint = other.transform.position;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bad"))
        {
            transform.position = checkpoint;
        }
    }

}
