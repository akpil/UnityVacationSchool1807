using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
    //public GameObject Bolt;
    private EnemyBoltPool boltPool;
    private GameController control;
    public Transform BoltPosition;

    public GameObject Explosion;

    public int ScoreValue;
    private SoundController soundControl;


    void Awake()
    {
        GameObject GC = GameObject.FindGameObjectWithTag("GameController");
        boltPool = GC.GetComponent<EnemyBoltPool>();
        control = GC.GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
    }

    
    void OnEnable () {
        rb.velocity = rb.transform.forward * Speed;
        soundControl = (GameObject.FindGameObjectWithTag("SoundController")).
                        GetComponent<SoundController>();

        StartCoroutine(Movement());
        StartCoroutine(AutoFire());
    }

    private IEnumerator AutoFire()
    {
        while (true)
        {
            //Instantiate(Bolt, BoltPosition.position, BoltPosition.rotation);
            Bolt temp = boltPool.GetFromPool();
            temp.gameObject.SetActive(true);
            temp.transform.position = BoltPosition.position;
            temp.transform.rotation = BoltPosition.rotation;
            soundControl.PlayerEffectSound((int)eSoundEffect.shotEnemy);
            yield return new WaitForSeconds(1);
        }
    }


    private IEnumerator Movement()
    {
        //그냥 하강
        float randomSleep = Random.Range(0.2f, 0.7f);
        float randomSpeed = Random.Range(2, 5);
        yield return new WaitForSeconds(randomSleep);
        //좌 혹은 우로 이동
        if (rb.transform.position.x >= 0)
        {
            rb.velocity += new Vector3(-randomSpeed, 0, 0);
        }
        else
        {
            rb.velocity += new Vector3(randomSpeed, 0, 0);
        }
        randomSleep = Random.Range(0.2f, 0.7f);
        yield return new WaitForSeconds(randomSleep);
        //이동상태에서 잠시 하강
        rb.velocity = rb.transform.forward * Speed;
        randomSleep = Random.Range(0.2f, 0.7f);
        yield return new WaitForSeconds(randomSleep);
        //원래 있던 자리의 방향으로 이동
        if (rb.transform.position.x >= 0)
        {
            rb.velocity += new Vector3(-randomSpeed, 0, 0);
        }
        else
        {
            rb.velocity += new Vector3(randomSpeed, 0, 0);
        }
        randomSleep = Random.Range(0.2f, 0.7f);
        yield return new WaitForSeconds(randomSleep);
        rb.velocity = rb.transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {            
            //GameController control = (GameObject.FindGameObjectWithTag("GameController")).GetComponent<GameController>();
            soundControl.PlayerEffectSound((int)eSoundEffect.expEnemy);
            control.AddScore(ScoreValue);
            GameObject exp = control.GetEffect(eParticleEffect.expEnemy);
            exp.transform.position = transform.position;
            exp.SetActive(true);

            gameObject.SetActive(false);
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameObject exp = control.GetEffect(eParticleEffect.expEnemy);
            exp.transform.position = transform.position;
            exp.SetActive(true);
            soundControl.PlayerEffectSound((int)eSoundEffect.expEnemy);
            gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update () {
        
	}
}
