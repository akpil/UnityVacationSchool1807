using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSoundEffect
{
    expAsteroid, expEnemy, expPlayer, shotEnemy, shotPlayer
}

public class SoundController : MonoBehaviour {

    public AudioSource BGM, Effect;
    public AudioClip BGMClip;
    public AudioClip[] EffectClips;

	// Use this for initialization
	void Start () {
        BGM.clip = BGMClip;
        BGM.Play();        
    }

    public void PlayerEffectSound(int index)
    {
        Effect.PlayOneShot(EffectClips[index]);
        //AudioSource.PlayClipAtPoint(EffectClips[index], Vector3.zero);
    }

	// Update is called once per frame
	void Update () {
    }
}
