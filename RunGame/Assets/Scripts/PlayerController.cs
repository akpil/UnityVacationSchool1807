using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int animRunHash;
    private int animJumpHash;
    private int animDieHash;
    private int animVeloHash;
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private float jumpVelocity;
    [SerializeField]
    private bool canJump;

    void Awake()
    {
        animRunHash = Animator.StringToHash("IsRun");
        animJumpHash = Animator.StringToHash("IsJump");
        animDieHash = Animator.StringToHash("IsDead");
        animVeloHash = Animator.StringToHash("VerticalVelocity");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = false;
    }

	// Use this for initialization
	void Start () {
		
	}

    public void StartRun()
    {
        anim.SetBool(animRunHash, true);
        canJump = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool(animJumpHash, false);
            if (anim.GetBool(animRunHash))
            {
                canJump = true;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            anim.SetBool(animJumpHash, true);
            rb.velocity = Vector2.up * jumpVelocity;
            canJump = false;
        }
        anim.SetFloat(animVeloHash, rb.velocity.y);
	}
}
