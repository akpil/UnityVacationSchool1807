using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour {

    private Rigidbody rb;
    public float AngularForce;
    public float Speed;

    public GameObject Explosion;

    public int ScoreValue;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere * AngularForce;
        rb.velocity = new Vector3(0, 0, -Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            GameObject exp = Instantiate(Explosion);
            exp.transform.position = transform.position;
            

            GameController control = (GameObject.FindGameObjectWithTag("GameController")).
                                            GetComponent<GameController>();
            control.AddScore(ScoreValue);
            (GameObject.FindGameObjectWithTag("SoundController")).
                GetComponent<SoundController>().
                PlayerEffectSound((int)eSoundEffect.expAstroid);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameObject exp = Instantiate(Explosion);
            exp.transform.position = transform.position;
            (GameObject.FindGameObjectWithTag("SoundController")).
                GetComponent<SoundController>().
                PlayerEffectSound((int)eSoundEffect.expAstroid);
            Destroy(gameObject);
        }
    }
}
