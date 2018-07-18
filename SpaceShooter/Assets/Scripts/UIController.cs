﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text scoreText;
    public Text gameOverText;
    public Text resetNotifyText;
    public Text lifeText;
    // Use this for initialization
    void Start () {
        scoreText.text = "Score : 0";
        gameOverText.text = "";
        resetNotifyText.text = "";
    }

    public void SetLife(int value)
    {
        lifeText.text = "X " + value.ToString();
    }

    public void SetScore(int value)
    {
        scoreText.text = "Score : " + value.ToString();
    }

    public void SetBossHP(float value)
    {
        
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        resetNotifyText.text = "To restart press 'Enter'";
    }

    public void Reset()
    {
        scoreText.text = "Score : 0";
        gameOverText.text = "";
        resetNotifyText.text = "";
    }

	// Update is called once per frame
	void Update () {
	}
}
