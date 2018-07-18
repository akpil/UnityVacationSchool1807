using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPool : MonoBehaviour {

    public BossController Enemy;
    private List<BossController> enemyPool;

    // Use this for initialization
    void Start()
    {
        enemyPool = new List<BossController>();
    }

    public BossController GetFromPool()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].gameObject.activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        BossController temp = Instantiate(Enemy);
        enemyPool.Add(temp);
        return temp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
