using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
    public GameObject Bolt;
    public Transform BoltPosition;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = rb.transform.forward * Speed;
        StartCoroutine(Movement());
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


	// Update is called once per frame
	void Update () {
        Instantiate(Bolt, BoltPosition.position, BoltPosition.rotation);
	}
}
