using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField]
    float timeScale;

    private void OnEnable()
    {
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(timeScale);
        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
