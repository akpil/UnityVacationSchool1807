using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score : 0";
	}

    public void SetScore(int value)
    {
        scoreText.text = "Score : " + value.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
