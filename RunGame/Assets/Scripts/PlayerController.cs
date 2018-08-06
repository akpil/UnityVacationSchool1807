using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int animRunHash;
    private int animJumpHash;
    private int animDieHash;
    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        animRunHash = Animator.StringToHash("IsRun");
        animJumpHash = Animator.StringToHash("IsJump");
        animDieHash = Animator.StringToHash("IsDead");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
		
	}

    public void StartRun()
    {
        anim.SetBool(animRunHash, true);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool(animJumpHash, true);
            rb.velocity = Vector2.up * 5;
        }
	}
}
