using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private BulletPool bulletP;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }

    public void Attack(double atk)
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

    public void SetDead()
    {
        anim.SetBool(AnimationHashList.AnimHashDead, true);
    }

    // Update is called once per frame
    void Update () {
        
    }
}
