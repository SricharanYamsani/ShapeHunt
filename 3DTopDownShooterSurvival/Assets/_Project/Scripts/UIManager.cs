using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject shopPanel;
    public GameObject shopButton;

    bool shopEnabled = false;

    public Text healthText;
    public Text ScoreText;

    public void UpdateScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void OpenShopPanel()
    {
        shopEnabled = true;
        shopPanel.SetActive(true);
        shopButton.SetActive(false);

        Time.timeScale = 0;
    }

    public void CloseShopPanel()
    {
        shopEnabled = false;
        shopPanel.SetActive(false);
        shopButton.SetActive(true);

        Time.timeScale = 1;
    }

    public void UpdateHealthText(float health)
    {
        healthText.text = health.ToString(); 
    }
}
