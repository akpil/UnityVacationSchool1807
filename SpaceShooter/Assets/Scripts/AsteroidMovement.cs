using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Rigidbody rb;
    public float AngularForce;
    public float Speed;

    public GameObject Explosion;

    public int ScoreValue;

    private GameController control;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void OnEnable () {
        rb.angularVelocity = Random.onUnitSphere * AngularForce;
        rb.velocity = new Vector3(0, 0, -Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            Hit();

            //Destroy(gameObject);
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            //GameObject exp = Instantiate(Explosion);
            //exp.transform.position = transform.position;
            if (control == null)
            {
                control = (GameObject.FindGameObjectWithTag("GameController")).
                                            GetComponent<GameController>();
            }
            GameObject exp = control.GetEffect(eParticleEffect.expAsteroid);
            exp.transform.position = transform.position;
            (GameObject.FindGameObjectWithTag("SoundController")).
                GetComponent<SoundController>().
                PlayerEffectSound((int)eSoundEffect.expAsteroid);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    public void Hit()
    {
        if (control == null)
        {
            control = (GameObject.FindGameObjectWithTag("GameController")).
                                        GetComponent<GameController>();
        }
        control.AddScore(ScoreValue);
        GameObject exp = control.GetEffect(eParticleEffect.expAsteroid);
        exp.transform.position = transform.position;
        exp.SetActive(true);

        (GameObject.FindGameObjectWithTag("SoundController")).
            GetComponent<SoundController>().
            PlayerEffectSound((int)eSoundEffect.expAsteroid);
        gameObject.SetActive(false);
    }
}
