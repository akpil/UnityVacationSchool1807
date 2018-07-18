using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    private Rigidbody rb;
    public Transform BoltPos;
    public float Speed;

    public int HP;
    private int currentHP;

    private bool hitFlag;

    private EnemyBoltPool boltPool;
    private SoundController soundControl;
    private GameController control;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        soundControl = GameObject.FindGameObjectWithTag("SoundController").
                                                GetComponent<SoundController>();
        boltPool = GameObject.FindGameObjectWithTag("BossPool").
                                                GetComponent<EnemyBoltPool>();
        control = GameObject.FindGameObjectWithTag("GameController").
                                                GetComponent<GameController>();
    }

    void OnEnable() {
        rb.velocity = transform.forward * Speed;
        HP = currentHP;
        hitFlag = false;
        StartCoroutine(BossMovement());
        control.SetBossHP(HP, currentHP);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            HP--;
            control.SetBossHP(HP, currentHP);
            other.gameObject.SetActive(false);
            if (HP <= 0)
            {
                soundControl.PlayerEffectSound((int)eSoundEffect.expEnemy);
                control.AddScore(10);
                GameObject exp = control.GetEffect(eParticleEffect.expEnemy);
                exp.transform.position = transform.position;
                exp.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
    private IEnumerator BossMovement()
    {
        while (true)
        {
            if (rb.position.z > 11.1)
            {
                yield return new WaitForSeconds(.3f);
            }
            else
            {
                break;
            }
        }
        hitFlag = true;
        while (true)
        {
            rb.velocity += new Vector3(-Speed, 0, 0);
            StartCoroutine(BossFire(2));
            yield return new WaitForSeconds(2);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(2);

            rb.velocity += new Vector3(Speed, 0, 0);
            StartCoroutine(BossFire(2));
            yield return new WaitForSeconds(2);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(2);

            rb.velocity += new Vector3(Speed, 0, 0);
            StartCoroutine(BossFire(2));
            yield return new WaitForSeconds(2);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(2);

            rb.velocity += new Vector3(-Speed, 0, 0);
            StartCoroutine(BossFire(4));
            yield return new WaitForSeconds(4);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(2);

            rb.velocity += new Vector3(Speed, 0, 0);
            StartCoroutine(BossFire(4));
            yield return new WaitForSeconds(4);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(2);

            rb.velocity += new Vector3(-Speed, 0, 0);
            StartCoroutine(BossFire(2));
            yield return new WaitForSeconds(2);
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator BossFire(float timer)
    {
        WaitForSeconds gap = new WaitForSeconds(.6f);
        while (timer > 0)
        {
            Bolt temp = boltPool.GetFromPool();
            temp.transform.position = BoltPos.position;
            temp.transform.rotation = BoltPos.rotation;
            temp.gameObject.SetActive(true);
            soundControl.PlayerEffectSound((int)eSoundEffect.shotEnemy);
            yield return gap;
            timer -= .6f;
        }
    }

	// Update is called once per frame
	void Update () {
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -4, 4),
                                  0,
                                  Mathf.Clamp(rb.position.z, 11, 19));
    }
}
