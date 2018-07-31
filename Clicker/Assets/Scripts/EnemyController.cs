using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float HideTimer;
    private Animator anim;

    [SerializeField]
    private EnemyAttackTrigger atkTrigger;

    private GameController control;

    private double currentHP;
    private double maxHP;
    [SerializeField]
    private Transform HPBarPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        control = GameObject.FindGameObjectWithTag("GameController").
                                        GetComponent<GameController>();
    }

    public void SetUP(double hp, float speed)
    {
        maxHP = currentHP = hp;
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

    private HPBarController hpbar;
    public void Hit(double value)
    {
        Debug.Log("hit damage : " + value.ToString());
        currentHP -= value;
        if (hpbar == null || !hpbar.gameObject.activeInHierarchy)
        {
            hpbar = control.GetHPBar();
            hpbar.gameObject.SetActive(true);
        }
        hpbar.transform.position = HPBarPos.position;
        if (currentHP <= 0 && !anim.GetBool(AnimationHashList.AnimHashDead))
        {
            anim.SetBool(AnimationHashList.AnimHashDead, true);
            rb.velocity = Vector2.zero;
            StartCoroutine(Hide());
            hpbar.ShowIncome(control.EarnMoney().ToString("N1"));
        }
        else
        {
            hpbar.SetHP((float)(currentHP / maxHP));
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
