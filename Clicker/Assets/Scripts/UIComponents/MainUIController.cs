using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour {
    [SerializeField]
    private Text MoneyText, AttackText;

    [SerializeField]
    ShopUIElementController[] ShopElemts;

	// Use this for initialization
	void Start () {
        MoneyText.text = "0";
        AttackText.text = "0";

        ShopElemts[0].SetUp("수입증가", "1");
        ShopElemts[1].SetUp("클릭데미지 증가", "1");
    }

    public void ShowMoney(double money)
    {
        MoneyText.text = UnitSetter.GetUnitString(money);
        ShopElemts[0].SetContents("1", money);
        ShopElemts[1].SetContents("1", money);
    }

    public void ShowAttack(double attack)
    {
        AttackText.text = UnitSetter.GetUnitString(attack);
    }

	// Update is called once per frame
	void Update () {
	}
}
