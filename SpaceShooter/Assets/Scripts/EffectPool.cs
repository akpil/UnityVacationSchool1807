using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eParticleEffect
{
    expAsteroid, expEnemy, expPlayer
}
public class EffectPool : MonoBehaviour {

    public GameObject[] Effects;
    private List<GameObject>[] effectPool;

    // Use this for initialization
    void Start()
    {
        effectPool = new List<GameObject>[Effects.Length];
        for (int i = 0; i < effectPool.Length; i++)
        {
            effectPool[i] = new List<GameObject>();
        }
    }

    public GameObject GetFromPool(int index)
    {
        for (int i = 0; i < effectPool[index].Count; i++)
        {
            if (!effectPool[index][i].gameObject.activeInHierarchy)
            {
                return effectPool[index][i];
            }
        }
        GameObject temp = Instantiate(Effects[index]);
        effectPool[index].Add(temp);
        return temp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
