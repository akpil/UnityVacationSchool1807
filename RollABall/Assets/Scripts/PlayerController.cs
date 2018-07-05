using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float Speed;

    public int Score;

    public UIController uicontrol;

    public GameObject[] pickupArr;

	// Use this for initialization
	void Start () {
        Score = 0;
        rb = GetComponent<Rigidbody>();
        GameObject uiObj = GameObject.FindGameObjectWithTag("UI");
        uicontrol = uiObj.GetComponent<UIController>();
        pickupArr = GameObject.FindGameObjectsWithTag("Pickup");
    }

    public void AddScore(int value)
    {
        Score += value;
        uicontrol.SetScoreText(Score);
        int count = 0;
        for (int i = 0; i < pickupArr.Length; i++)
        {
            if (pickupArr[i].activeInHierarchy)
            {
                count++;
            }
        }
        if (count == 0)
        {
            uicontrol.Finish();
        }
    }

	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0, 4, 0);
        }
        rb.velocity = new Vector3(horizontal, rb.velocity.y, vertical) ;
    }
}
