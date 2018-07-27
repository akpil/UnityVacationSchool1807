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

    [SerializeField]
    private EnemyAttackTrigger atkTrigger;

    private GameController control;

    private double currentHP;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        control = GameObject.FindGameObjectWithTag("GameController").
                                        GetComponent<GameController>();
    }

    public void SetUP(double hp, float speed)
    {
        currentHP = hp;
        Speed = speed;
        rb.velocity = Vector2.left * Speed;
    }

    void OnEnable()
    {
        rb.velocity = Vector2.left * Speed;
    }

    void OnDisable()
    {
        atkTrigger.ResetTarget();
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
        if (currentHP <= 0 && !anim.GetBool(AnimationHashList.AnimHashDead))
        {
            anim.SetBool(AnimationHashList.AnimHashDead, true);
            rb.velocity = Vector2.zero;
            StartCoroutine(Hide());
            control.EarnMoney();
        }
    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(HideTimer);
        gameObject.SetActive(false);
    }

    public void PlayerAttack()
    {
        control.LooseMoney();
    }

	// Update is called once per frame
	void Update () {
        
	}
}
