using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterPool : MonoBehaviour {
    [SerializeField]
    private SupporterController supporter;
    [SerializeField]
    private Transform[] supporterPosArr;
    private List<SupporterController> supporeterList;
    [SerializeField]
    private BulletPool supporterBulletPool;
	// Use this for initialization
	void Awake () {
        supporeterList = new List<SupporterController>();
    }
	
    public SupporterController GetFromPool(int posIndex)
    {
        for (int i = 0; i < supporeterList.Count; i++)
        {
            if (!supporeterList[i].gameObject.activeInHierarchy)
            {
                supporeterList[i].transform.position = supporterPosArr[posIndex].position;
                supporeterList[i].gameObject.SetActive(true);
                return supporeterList[i];
            }
        }
        SupporterController temp = Instantiate(supporter);
        temp.SetBulletPool(supporterBulletPool);
        temp.transform.position = supporterPosArr[posIndex].position;
        supporeterList.Add(temp);
        return temp;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
