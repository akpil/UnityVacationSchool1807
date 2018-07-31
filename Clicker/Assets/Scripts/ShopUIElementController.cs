using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIElementController : MonoBehaviour {

    [SerializeField]
    Text titleText,
        contentsText,
        purchaseText;
    [SerializeField]
    Button purchaseButton;

	// Use this for initialization
	void Start () {
        SetUp("수입", "100", "100K");
    }

    public void SetUp(string title, string contents, string cost)
    {
        titleText.text = title;
        contentsText.text = string.Format(contentsText.text, contents);
        purchaseText.text = string.Format(purchaseText.text, cost);

        string.Format("text string is {0}, {1}", 10, 20);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
