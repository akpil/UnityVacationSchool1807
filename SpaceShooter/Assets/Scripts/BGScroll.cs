using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {
    public float Speed;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -Speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BGTrigger"))
        {
            rb.position += new Vector3(0, 0, 40.96f);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
