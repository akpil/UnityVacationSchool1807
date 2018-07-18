using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] Asteroid;
    public Rigidbody[] Asteroid2;
    public GameObject Enemy;
    public PlayerController Player;
    public int Score;

    public float StartWaitingTime;
    public float StageTimeGap;

    public UIController ui;

    private Coroutine harzardRoutine;
    public BGScroll[] BGs;

    private bool isGameOver;

    private AsteroidPool AsteroidP;
    private EnemyPool EnemyP;
    private EffectPool EffectP;
    private ItemPool ItemP;
    private BossPool BossP;
    private bool IsBossAlive;
    public int BossSpawnCount;
    private int CurrentBossSpawnCount;

    public int StartLifeCount;
    public int CurrentLifeCount;
    private int ItemSpawnCount;

    // Use this for initialization
    void Start () {
        //InvokeRepeating("SpawnHazards", 2, 3);
        isGameOver = false;
        ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        AsteroidP = GetComponent<AsteroidPool>();
        EffectP = GetComponent<EffectPool>();
        EnemyP = GetComponent<EnemyPool>();
        ItemP = GetComponent<ItemPool>();
        BossP = GameObject.FindGameObjectWithTag("BossPool").GetComponent<BossPool>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        CurrentLifeCount = StartLifeCount;
        ui.SetLife(CurrentLifeCount);
        ItemSpawnCount = 0;
        IsBossAlive = false;
        CurrentBossSpawnCount = BossSpawnCount;
        harzardRoutine = StartCoroutine(Hazards(StartWaitingTime, StageTimeGap));
    }

    private IEnumerator Hazards(float startTime, float stageGap)
    {
        WaitForSeconds gap = new WaitForSeconds(stageGap);
        WaitForSeconds spawnGap = new WaitForSeconds(.2f);
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            int randInt = Random.Range(5, 11);
            int randEnem = Random.Range(3, 6);
            while (randInt > 0 || randEnem > 0)
            {
                if (randInt > 0 && randEnem > 0)
                {
                    int val = Random.Range(0, 2);
                    if (val == 0)
                    {
                        //GameObject temp = Instantiate(Asteroid[Random.Range(0, Asteroid.Length)]);
                        AsteroidMovement temp = AsteroidP.GetFromPool(Random.Range(0, 3));
                        temp.gameObject.SetActive(true);
                        float randPosX = Random.Range(-5f, 5f);
                        temp.transform.position = new Vector3(randPosX, temp.transform.position.y, 16.5f);
                        randInt--;
                    }
                    else
                    {
                        //GameObject temp = Instantiate(Enemy);
                        EnemyController temp = EnemyP.GetFromPool();
                        temp.gameObject.SetActive(true);
                        float randPosX = Random.Range(-5f, 5f);
                        temp.transform.position = new Vector3(randPosX, temp.transform.position.y, 16.5f);
                        randEnem--;
                    }
                }
                else if (randInt <= 0)
                {
                    EnemyController temp = EnemyP.GetFromPool();
                    temp.gameObject.SetActive(true);
                    float randPosX = Random.Range(-5f, 5f);
                    temp.transform.position = new Vector3(randPosX, temp.transform.position.y, 16.5f);
                    randEnem--;
                }
                else if (randEnem <= 0)
                {
                    //GameObject temp = Instantiate(Asteroid[Random.Range(0, Asteroid.Length)]);
                    AsteroidMovement temp = AsteroidP.GetFromPool(Random.Range(0, 3));
                    temp.gameObject.SetActive(true);
                    float randPosX = Random.Range(-5f, 5f);
                    temp.transform.position = new Vector3(randPosX, temp.transform.position.y, 16.5f);
                    randInt--;
                }
                yield return spawnGap;
            }
            CurrentBossSpawnCount--;
            yield return gap;
            if (CurrentBossSpawnCount <= 0)
            {
                BossController boss = BossP.GetFromPool();
                boss.transform.position = new Vector3(0, boss.transform.position.y, 18.5f);
                boss.gameObject.SetActive(true);
                IsBossAlive = true;
            }
            while (IsBossAlive)
            {
                yield return gap;
            }
        }
    }

    private void SpawnHazards()
    {
        int randInt = Random.Range(5,11);
        for (int i = 0; i < randInt; i++)
        {
            GameObject temp = Instantiate(Asteroid[Random.Range(0, Asteroid.Length)]);
            float randPosX = Random.Range(-5, 5);
            temp.transform.position = new Vector3(randPosX, temp.transform.position.y, temp.transform.position.z);
        }
    }

    public void SetBossHP(int current, int max)
    {
        if (current <= 0)
        {
            IsBossAlive = false;
        }
        ui.SetBossHP((float)current / max);
    }

    public void AddScore(int value)
    {
        ItemSpawnCount++;
        Score += value;
        ui.SetScore(Score);
        if (ItemSpawnCount >= 5)
        {
            ItemSpawnCount -= 5;
            GameObject temp = ItemP.GetFromPool(Random.Range(0, 2));
            temp.gameObject.SetActive(true);
            float randPosX = Random.Range(-5f, 5f);
            temp.transform.position = new Vector3(randPosX, temp.transform.position.y, 16.5f);
        }
    }

    public GameObject GetEffect(eParticleEffect index)
    {
        return EffectP.GetFromPool((int)index);
    }

    public void AddLife(int value)
    {
        CurrentLifeCount += value;
        ui.SetLife(CurrentLifeCount);
    }

    public void ChangeBolt()
    {
        Player.ChangeBolt(5);
    }

    public void Restart()
    {
        harzardRoutine = StartCoroutine(Hazards(StartWaitingTime, StageTimeGap));
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].StartScrolling();
        }
        ui.Reset();
        isGameOver = false;
        Score = 0;

        CurrentLifeCount = StartLifeCount;
        ui.SetLife(CurrentLifeCount);

        Player.gameObject.SetActive(true);
        Player.transform.position = Vector3.zero;
    }

    public void GameOver()
    {
        EnemyP.StopAll();
        AsteroidP.StopAll();
        if (CurrentLifeCount > 1)
        {
            Player.gameObject.SetActive(true);
            Player.transform.position = Vector3.zero;
        }
        else
        {
            StopCoroutine(harzardRoutine);
            for (int i = 0; i < BGs.Length; i++)
            {
                BGs[i].StopScrolling();
            }
            ui.GameOver();
            isGameOver = true;
        }
        CurrentLifeCount--;
        ui.SetLife(CurrentLifeCount);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && isGameOver)
        {
            //SceneManager.LoadScene(0);
            Restart();
        }
	}
}
