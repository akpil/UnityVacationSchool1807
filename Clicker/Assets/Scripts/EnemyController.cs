using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Animator anim;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * Speed;
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player!!");
            anim.SetBool(AnimationHashList.AnimHashAttack, true);
        }
    }

    public void Hit(float value)
    {
        Debug.Log("hit damage : " + value.ToString());
    }

	// Update is called once per frame
	void Update () {
        
	}
}
