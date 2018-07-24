using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").
                                GetComponent<PlayerController>();
	}

    public void Touch()
    {
        player.Attack();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
