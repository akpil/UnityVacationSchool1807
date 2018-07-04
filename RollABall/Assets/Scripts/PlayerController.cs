using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float Speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0, 4, 0);
        }
        rb.velocity = new Vector3(horizontal, rb.velocity.y, vertical) ;
    }
}
