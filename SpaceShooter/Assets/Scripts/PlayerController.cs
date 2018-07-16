using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float Speed;
    public float RotateAngle;
    public GameObject Bolt;
    public Transform BoltPos;
    public float FireRate;
    private float currentRate;

    public GameObject Explosion;

    private SoundController soundControl;

    private PlayerBoltPool boltPool;

    private GameController control;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentRate = 0;
        soundControl = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        boltPool = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerBoltPool>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal, 0, vertical) * Speed;

        rb.rotation = Quaternion.Euler(new Vector3(0, 0, -horizontal * RotateAngle));

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -5, 5),
                                  0,
                                  Mathf.Clamp(rb.position.z, -4, 9));

        if (Input.GetButton("Fire1") && currentRate <= 0)
        {
            //GameObject temp = Instantiate(Bolt);
            Bolt temp = boltPool.GetFromPool();
            temp.gameObject.SetActive(true);
            temp.transform.position = BoltPos.position;
            currentRate = FireRate;
            soundControl.PlayerEffectSound((int)eSoundEffect.shotPlayer);
        }
        currentRate -= Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (control == null)
            {
                control = (GameObject.FindGameObjectWithTag("GameController")).
                GetComponent<GameController>();
            }
            GameObject exp = control.GetEffect(eParticleEffect.expPlayer);
            exp.transform.position = transform.position;
            exp.SetActive(true);
            soundControl.PlayerEffectSound((int)eSoundEffect.expPlayer);
            gameObject.SetActive(false);
            control.GameOver();
        }
    }
}
