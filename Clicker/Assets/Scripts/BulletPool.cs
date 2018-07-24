using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    [SerializeField]
    private Bullet bullet;

    private List<Bullet> bulletList;

	// Use this for initialization
	void Awake () {
        bulletList = new List<Bullet>();
	}

    public Bullet GetFromPool()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].gameObject.activeInHierarchy)
            {
                return bulletList[i];
            }
        }
        Bullet temp = Instantiate(bullet);
        bulletList.Add(temp);
        return temp;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
