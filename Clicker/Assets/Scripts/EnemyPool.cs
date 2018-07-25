using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    [SerializeField]
    private EnemyController enemy;

    private List<EnemyController> enemyList;

    // Use this for initialization
    void Awake()
    {
        enemyList = new List<EnemyController>();
    }

    public EnemyController GetFromPool()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].gameObject.activeInHierarchy)
            {
                return enemyList[i];
            }
        }
        EnemyController temp = Instantiate(enemy);
        enemyList.Add(temp);
        return temp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
