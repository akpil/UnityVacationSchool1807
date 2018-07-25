using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float HideTimer;
    [SerializeField]
    private Animator anim;

    private double currentHP;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void SetUP(double hp, float speed)
    {
        currentHP = hp;
        Speed = speed;
    }

    void OnEnable()
    {
        rb.velocity = Vector2.left * Speed;
    }



	// Use this for initialization
	void Start () {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player!!");
            anim.SetBool(AnimationHashList.AnimHashAttack, true);
        }
    }

    public void Hit(double value)
    {
        Debug.Log("hit damage : " + value.ToString());
        currentHP -= value;
        if (currentHP <= 0)
        {
            anim.SetBool(AnimationHashList.AnimHashDead, true);
            rb.velocity = Vector2.zero;
            StartCoroutine(Hide());
        }
    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(HideTimer);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        
	}
}
