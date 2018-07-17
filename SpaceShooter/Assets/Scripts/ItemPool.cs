using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour {

    public GameObject[] Items;
    private List<GameObject>[] itemPool;

    // Use this for initialization
    void Start()
    {
        itemPool = new List<GameObject>[Items.Length];
        for (int i = 0; i < itemPool.Length; i++)
        {
            itemPool[i] = new List<GameObject>();
        }
    }

    public GameObject GetFromPool(int index)
    {
        for (int i = 0; i < itemPool[index].Count; i++)
        {
            if (!itemPool[index][i].gameObject.activeInHierarchy)
            {
                return itemPool[index][i];
            }
        }
        GameObject temp = Instantiate(Items[index]);
        itemPool[index].Add(temp);
        return temp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
