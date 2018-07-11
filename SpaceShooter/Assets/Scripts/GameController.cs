using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] Astroid;
    public Rigidbody[] Astroid2;
    public GameObject Enemy;

    public int Score;

    public float StartWaitingTime;
    public float StageTimeGap;
    // Use this for initialization
    void Start () {
        //InvokeRepeating("SpawnHazards", 2, 3);
        StartCoroutine(Hazards(StartWaitingTime, StageTimeGap));
        
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
                        GameObject temp = Instantiate(Astroid[Random.Range(0, Astroid.Length)]);
                        float randPosX = Random.Range(-5f, 5f);
                        temp.transform.position = new Vector3(randPosX, temp.transform.position.y, temp.transform.position.z);
                        randInt--;
                    }
                    else
                    {
                        GameObject temp = Instantiate(Enemy);
                        float randPosX = Random.Range(-5f, 5f);
                        temp.transform.position = new Vector3(randPosX, temp.transform.position.y, temp.transform.position.z);
                        randEnem--;
                    }
                }
                else if (randInt <= 0)
                {
                    GameObject temp = Instantiate(Enemy);
                    float randPosX = Random.Range(-5f, 5f);
                    temp.transform.position = new Vector3(randPosX, temp.transform.position.y, temp.transform.position.z);
                    randEnem--;
                }
                else if (randEnem <= 0)
                {
                    GameObject temp = Instantiate(Astroid[Random.Range(0, Astroid.Length)]);
                    float randPosX = Random.Range(-5f, 5f);
                    temp.transform.position = new Vector3(randPosX, temp.transform.position.y, temp.transform.position.z);
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
            GameObject temp = Instantiate(Astroid[Random.Range(0, Astroid.Length)]);
            float randPosX = Random.Range(-5, 5);
            temp.transform.position = new Vector3(randPosX, temp.transform.position.y, temp.transform.position.z);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
