using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSummaryMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Text scoreText;

    public Action OnNewLevelClicked;

    void Start()
    {
        menuPanel.SetActive(false);
    }        

    public void LevelSummary(int pointValue)
    {
        menuPanel.SetActive(true);
        scoreText.text = pointValue.ToString();
    }

    private void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    public void NewLevelClick()
    {
        OnNewLevelClicked?.Invoke();
        CloseMenu();
    }
}
