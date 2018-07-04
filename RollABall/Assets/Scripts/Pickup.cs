using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Vector3 rotatePerSec;
    private Vector3 rotatePerFrame;
    void Start()
    {
        rotatePerFrame = rotatePerSec * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(rotatePerFrame);
    }
}
