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
    private HPBarPool enemyHPP;

    [SerializeField]
    private double money;

    [SerializeField]
    private double playerAtk;

    [SerializeField]
    private int killCount;

    [SerializeField]
    private double baseIncome,  currentIncome;
    [SerializeField]
    private float incomeWeight;
    [SerializeField]
    private int enemyLevel, exp;

    private MainUIController UI;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").
                                GetComponent<PlayerController>();
        UI = GameObject.FindGameObjectWithTag("UI").
                                GetComponent<MainUIController>();
        money = 0;
        playerAtk = 1;
        killCount = 0;
        enemyLevel = 0;
        baseIncome = 10;
        incomeWeight = 1.03f;
        currentIncome = baseIncome * Mathf.Pow(incomeWeight,enemyLevel);

    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void Touch()
    {
        player.Attack(playerAtk);
    }

    public double EarnMoney()
    {
        exp++;
        if (exp % 10 == 0)
        {
            enemyLevel++;
            currentIncome = baseIncome * Mathf.Pow(incomeWeight, enemyLevel);
        }
        money += currentIncome;
        UI.ShowMoney(money);
        return currentIncome;
    }

    public void PowerUP()
    {
        if (money >= 100)
        {
            playerAtk++;
            money -= 100;
            UI.ShowMoney(money);
        }
    }

    public void AutoIncome()
    {
        Debug.Log("auto income clicked");
    }

    public void LooseMoney()
    {
        money--;
        if (money <= 0)
        {
            player.SetDead();
        }
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

    public void TempSpawn()
    {
        EnemyController temp = enemyP.GetFromPool();
        temp.transform.position = enemySpawnPoint.position;
        temp.SetUP(20, .5f);
        temp.gameObject.SetActive(true);
    }

    public HPBarController GetHPBar()
    {
        return enemyHPP.GetFromPool();
    }

    public void MakeHPBar()
    {
        enemyHPP.GetFromPool();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
