using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarPool : MonoBehaviour {
    [SerializeField]
    private HPBarController HPBar;

    [SerializeField]
    private Transform Canvas;

    private List<HPBarController> HPBarList;

    // Use this for initialization
    void Awake()
    {
        HPBarList = new List<HPBarController>();
    }

    public HPBarController GetFromPool()
    {
        for (int i = 0; i < HPBarList.Count; i++)
        {
            if (!HPBarList[i].gameObject.activeInHierarchy)
            {
                return HPBarList[i];
            }
        }
        HPBarController temp = Instantiate(HPBar);
        temp.transform.SetParent(Canvas);
        temp.transform.localScale = Vector3.one;
        HPBarList.Add(temp);
        return temp;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
