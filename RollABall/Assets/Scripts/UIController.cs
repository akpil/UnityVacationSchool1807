using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreText;
    public Text FinishText;
    // Use this for initialization
    void Start () {
        ScoreText.text = "Score : 0";
        FinishText.text = "";
	}

    public void SetScoreText(int value)
    {
        ScoreText.text = "Score : " + value.ToString();
    }

    public void Finish()
    {
        FinishText.text = "Finish!!!!";
    }

	// Update is called once per frame
	void Update () {
		
	}
}
