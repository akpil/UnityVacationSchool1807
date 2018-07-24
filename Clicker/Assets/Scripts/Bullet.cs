using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]
    private float Speed;
    private float atk;

    private void Awake()
    {
        atk = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rb.velocity = new Vector2(Speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy!!!");
            gameObject.SetActive(false);
            other.SendMessage("Hit", atk);
        }
    }

    public void SetAtk(float value)
    {
        atk = value;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
