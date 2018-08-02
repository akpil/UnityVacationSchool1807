using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eShopElementType
{
    PowerUp,
    AutoIncome
};

public class ShopUIElementController : MonoBehaviour {

    [SerializeField]
    Text titleText,
        contentsText,
        purchaseText;
    [SerializeField]
    Button purchaseButton;

    [SerializeField]
    private eShopElementType elemType;

    [SerializeField]
    private double upgradeCost;
	// Use this for initialization
	void Start () {
        purchaseButton.interactable = false;
        GameController control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        switch (elemType)
        {
            case eShopElementType.AutoIncome:
                purchaseButton.onClick.AddListener(control.AutoIncome);
                break;
            case eShopElementType.PowerUp:
                purchaseButton.onClick.AddListener(control.PowerUP);
                break;
        }
    }

    public void SetUp(string title, string contents)
    {
        titleText.text = title;
        contentsText.text = string.Format(contentsText.text, contents);
        purchaseText.text = string.Format(purchaseText.text, UnitSetter.GetUnitString(upgradeCost));
    }

    public void SetContents(string contents, double value)
    {
        if (upgradeCost <= value)
        {
            purchaseButton.interactable = true;
        }
        contentsText.text = string.Format(contentsText.text, contents);
        purchaseText.text = string.Format(purchaseText.text, UnitSetter.GetUnitString(upgradeCost));
    }

    public void SetPurchasable(bool isPurchasable)
    {
        purchaseButton.interactable = isPurchasable;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
