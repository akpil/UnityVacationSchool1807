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

    public void Attack()
    {
        anim.SetBool(AnimationHashList.AnimHashAttack, true);
        Bullet t = bulletP.GetFromPool();
        t.transform.position = bulletPos.position;
        t.gameObject.SetActive(true);
    }
    public void AttackFinish()
    {
        anim.SetBool(AnimationHashList.AnimHashAttack, false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool(AnimationHashList.AnimHashDead, true);
        }
    }
}
