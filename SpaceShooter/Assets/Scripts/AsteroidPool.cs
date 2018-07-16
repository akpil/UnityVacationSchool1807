using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour {
    public AsteroidMovement[] Asteroids;
    private List<AsteroidMovement>[] AsteroidsPool;

	// Use this for initialization
	void Start () {
        AsteroidsPool = new List<AsteroidMovement>[Asteroids.Length];
        for (int i = 0; i < AsteroidsPool.Length; i++)
        {
            AsteroidsPool[i] = new List<AsteroidMovement>();
        }
	}

    public AsteroidMovement GetFromPool(int index)
    {
        for (int i = 0; i < AsteroidsPool[index].Count; i++)
        {
            if (!AsteroidsPool[index][i].gameObject.activeInHierarchy)
            {
                return AsteroidsPool[index][i];
            }
        }
        AsteroidMovement temp = Instantiate(Asteroids[index]);
        AsteroidsPool[index].Add(temp);
        return temp;
    }
    public void StopAll()
    {
        for (int i = 0; i < AsteroidsPool.Length; i++)
        {
            for (int j = 0; j < AsteroidsPool[i].Count; j++)
            {
                AsteroidsPool[i][j].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
