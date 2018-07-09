using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour {

    private Rigidbody rb;
    public float AngularForce;
    public float Speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere * AngularForce;
        rb.velocity = new Vector3(0, 0, -Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
}
