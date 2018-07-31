using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour {

    [SerializeField]
    private GameObject HPBar, Incomebox;
    [SerializeField]
    private Image HP;
    [SerializeField]
    private Text incomeText;

    void OnEnable()
    {
        HPBar.SetActive(true);
        Incomebox.SetActive(false);
        HP.fillAmount = 1;
    }

    public void SetHP(float HPPercent)
    {
        HP.fillAmount = HPPercent;
    }

    public void ShowIncome(string income)
    {
        incomeText.text = income;
        HPBar.SetActive(false);
        Incomebox.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
