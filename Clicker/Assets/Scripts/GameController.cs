using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private PlayerController player;

    [SerializeField]
    private Transform enemySpawnPoint;
    [SerializeField]
    private EnemyPool enemyP;

    [SerializeField]
    private double money;

    [SerializeField]
    private double playerAtk;

    [SerializeField]
    private int killCount;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").
                                GetComponent<PlayerController>();
        money = 0;
        playerAtk = 1;
        killCount = 0;
	}

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void Touch()
    {
        player.Attack(playerAtk);
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            EnemyController temp = enemyP.GetFromPool();
            temp.transform.position = enemySpawnPoint.position;
            temp.SetUP(20, .5f);
            temp.gameObject.SetActive(true);
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
