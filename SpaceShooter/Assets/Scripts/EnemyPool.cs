using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public EnemyController Enemy;
    private List<EnemyController> enemyPool;

	// Use this for initialization
	void Start () {
        enemyPool = new List<EnemyController>();
	}

    public EnemyController GetFromPool()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].gameObject.activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        EnemyController temp = Instantiate(Enemy);
        enemyPool.Add(temp);
        return temp;
    }

    public void StopAll()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            enemyPool[i].gameObject.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
