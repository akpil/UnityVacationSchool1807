using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] Asteroid;
    public Rigidbody[] Asteroid2;
    public GameObject Enemy;
    public GameObject Player;
    public int Score;

    public float StartWaitingTime;
    public float StageTimeGap;

    public UIController ui;

    private Coroutine harzardRoutine;
    public BGScroll[] BGs;

    private bool isGameOver;

    private AsteroidPool AsteroidP;
    private EffectPool EffectP;


    // Use this for initialization
    void Start () {
        //InvokeRepeating("SpawnHazards", 2, 3);
        isGameOver = false;
        ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        AsteroidP = GetComponent<AsteroidPool>();
        EffectP = GetComponent<EffectPool>();

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
                        GameObject temp = Instantiate(Enemy);
                        float randPosX = Random.Range(-5f, 5f);
                        temp.transform.position = new Vector3(randPosX, temp.transform.position.y, 16.5f);
                        randEnem--;
                    }
                }
                else if (randInt <= 0)
                {
                    GameObject temp = Instantiate(Enemy);
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
            yield return gap;
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

    public void AddScore(int value)
    {
        Score += value;
        ui.SetScore(Score);
    }

    public GameObject GetEffect(eParticleEffect index)
    {
        return EffectP.GetFromPool((int)index);
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
        Instantiate(Player);
    }

    public void GameOver()
    {
        StopCoroutine(harzardRoutine);
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].StopScrolling();
        }
        ui.GameOver();
        isGameOver = true;
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
