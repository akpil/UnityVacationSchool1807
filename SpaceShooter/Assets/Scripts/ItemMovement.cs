using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{

    private Rigidbody rb;
    public float AngularForce;
    public float Speed;

    private GameController control;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * AngularForce;
        rb.velocity = new Vector3(0, 0, -Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (control == null)
            {
                control = (GameObject.FindGameObjectWithTag("GameController")).
                                            GetComponent<GameController>();
            }
            if (gameObject.CompareTag("BoltChange"))
            {

            }
            else if (gameObject.CompareTag("LifeUp"))
            {

            }
            gameObject.SetActive(false);
        }
    }
}
