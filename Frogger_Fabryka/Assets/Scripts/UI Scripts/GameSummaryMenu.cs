using System;
using System.Collections.Generic;
using UnityEngine;


public class GameSummaryMenu : MonoBehaviour
{
    private int _scoreRecordsOnList = 5;
    [SerializeField] GameObject menuPanel;
    [SerializeField] ScoreRecordPrefab scoreRegisPrefab;
    [SerializeField] Transform ScoreBoardTransform;    

    private List<int> ScoresList = new List<int> { 0, 0, 0, 0, 0 };
    private List<ScoreRecordPrefab> scoreRegisList = new List<ScoreRecordPrefab>();

    public Action OnNewGameClick;

    private void Start()
    {
        menuPanel.SetActive(false);        
        CreateLeaderbord();
    }

    public void GameSummary(int pointValue)
    {
        menuPanel.SetActive(true);
        UpdateLeaderboard(pointValue);
    }

    private void CreateLeaderbord()
    {
        for (int i = 0; i < _scoreRecordsOnList; i++)
        {
            ScoreRecordPrefab scoreRecord = Instantiate(scoreRegisPrefab, ScoreBoardTransform);
            scoreRegisList.Add(scoreRecord);
        }
    }

    private void UpdateLeaderboard(int pointValue)
    {
        ScoresList.Add(pointValue);
        ScoresList.Sort((i, j) => j.CompareTo(i));
        foreach (var item in scoreRegisList)
        {
            int scoreToPass = ScoresList[scoreRegisList.IndexOf(item)];
            int rankToPass = scoreRegisList.IndexOf(item) + 1;
            item.UpdateTextFields(rankToPass, scoreToPass );
        }
    }

    private void CloseMenu()
    {
        menuPanel.SetActive(false);
    }

    public void NewGameClick()
    {
        OnNewGameClick?.Invoke();
        CloseMenu();
    }
}
