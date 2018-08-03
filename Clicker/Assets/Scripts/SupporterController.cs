using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterController : MonoBehaviour {
    private Animator anim;

    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private BulletPool bulletP;
    [SerializeField]
    private double atk;
    [SerializeField]
    private float atkPeriod;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        StartCoroutine(AutoAttack());
    }
    private IEnumerator AutoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(atkPeriod);
            Attack();
        }
        
    }

    public void SetBulletPool(BulletPool pool)
    {
        bulletP = pool;
    }

    private void Attack()
    {
        if (!anim.GetBool(AnimationHashList.AnimHashDead))
        {
            anim.SetBool(AnimationHashList.AnimHashAttack, true);
            Bullet t = bulletP.GetFromPool();
            t.transform.position = bulletPos.position;
            t.SetAtk(atk);
            t.gameObject.SetActive(true);
        }
    }
    public void AttackFinish()
    {
        anim.SetBool(AnimationHashList.AnimHashAttack, false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
