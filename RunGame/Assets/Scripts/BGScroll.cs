using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 rollbackAmount;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rollbackAmount = new Vector2(37.52f, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BG"))
        {
            rb.position += rollbackAmount;
        }
    }

    public void SetSpeed(float speed)
    {
        rb.velocity = Vector2.left * speed;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
