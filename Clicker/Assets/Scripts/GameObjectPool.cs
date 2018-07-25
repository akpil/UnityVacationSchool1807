using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour {
    [SerializeField]
    private GameObject obj;

    private List<GameObject> objList;

    // Use this for initialization
    void Awake()
    {
        objList = new List<GameObject>();
    }

    public GameObject GetFromPool()
    {
        for (int i = 0; i < objList.Count; i++)
        {
            if (!objList[i].gameObject.activeInHierarchy)
            {
                return objList[i];
            }
        }
        GameObject temp = Instantiate(obj);
        objList.Add(temp);
        return temp;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
