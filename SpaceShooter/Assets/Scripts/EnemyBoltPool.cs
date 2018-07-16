using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltPool : MonoBehaviour {
    public Bolt enemyBolt;
    private List<Bolt> boltPool;
    // Use this for initialization
    void Start()
    {
        boltPool = new List<Bolt>();
    }

    public Bolt GetFromPool()
    {
        for (int i = 0; i < boltPool.Count; i++)
        {
            if (!boltPool[i].gameObject.activeInHierarchy)
            {
                return boltPool[i];
            }
        }
        Bolt temp = Instantiate(enemyBolt);
        boltPool.Add(temp);
        return temp;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
