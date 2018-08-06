using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private BGScroll[] BGs;
    [SerializeField]
    private float ScrollingSpeed;
    [SerializeField]
    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(StartCountdown());
	}

    private IEnumerator StartCountdown()
    {
        float timer = 3f;
        WaitForSeconds gap = new WaitForSeconds(.1f);
        while (timer >= 0)
        {
            // print countdown
            Debug.Log(timer);
            yield return gap;
            timer -= .1f;
        }
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetSpeed(ScrollingSpeed);
        }
        player.StartRun();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
