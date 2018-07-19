using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {

    public float Gap;

	// Use this for initialization
	void OnEnable () {
        StartCoroutine(DestroyAfterGap());
	}

    private IEnumerator DestroyAfterGap()
    {
        yield return new WaitForSeconds(Gap);
        gameObject.SetActive(false);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
