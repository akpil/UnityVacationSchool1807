using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {

    public float Gap;

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyAfterGap());
	}

    private IEnumerator DestroyAfterGap()
    {
        yield return new WaitForSeconds(Gap);
        Destroy(gameObject);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
