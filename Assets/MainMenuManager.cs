using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public float money;
    public TextMeshProUGUI moneyDisp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money=PlayerPrefs.GetFloat("Money", 100);
        PlayerPrefs.SetFloat("Money",money);
        PlayerPrefs.Save();
        moneyDisp.text=Utils.formatMoney(money);
    }

   
}
