using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    GameController control;

    [SerializeField]
    private GameObjectPool touchEffectPool;

	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").
                                    GetComponent<GameController>();
	}

    private bool TouchCheck()
    {
        return Input.touchCount > 0 || Input.GetMouseButtonDown(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (TouchCheck())
        {
            Vector3 ori = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, 
                                Input.mousePosition.y,
                                Camera.main.nearClipPlane));
            Vector3 far = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x,
                                Input.mousePosition.y,
                                Camera.main.farClipPlane));
            Vector3 direction = far - ori;
            RaycastHit hit;

            if (Physics.Raycast(ori, direction, out hit))
            { 
                control.Touch();
                GameObject temp = touchEffectPool.GetFromPool();
                temp.transform.position = hit.point;
                temp.SetActive(true);
            }
        }
	}
}
