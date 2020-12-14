using System;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private int frogLifes = 3;
    [SerializeField] private int _leafsReachedToCompleteLevel = 3;
    [SerializeField] private int _gameLevelsToCompleteGame = 2;
    [SerializeField] private int pointsForLane = 10;
    [SerializeField] private Timer timer;

    public int PlayerPoints { get; set; }
    private int FrogLifes { get; set; }
    [HideInInspector] public bool isPaused;
    private int _playerPoints;
    private int _leafsReached;
    private int _levelsComplete;
        
    public Action OnLevelComplete;
    public Action OnGameComplete;

    public Action<int> OnLifesAmountChange;    
    public Action OnLostAllLifes;

    public Action<bool> OnPauseStatusChange;
    public Action<float> OnPointsRecived;

    private void Start() 
    {
        isPaused = false;
        OnPauseStatusChange?.Invoke(isPaused);
        _playerPoints = 0;   
        _leafsReached = 0;
        ReplenishHealth();
    }


    private void Update()
    {
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void PauseGame()
    {
        isPaused = true;
        OnPauseStatusChange?.Invoke(isPaused);
    }

    public void UnpauseGame()
    {
        isPaused = false;
        OnPauseStatusChange?.Invoke(isPaused);
    }

    private void ReplenishHealth()
    {
        FrogLifes = frogLifes;
        OnLifesAmountChange?.Invoke(FrogLifes);
    }

    public void HandleFrogDeath()
    {
        FrogLifes--;
        OnLifesAmountChange?.Invoke(FrogLifes);
        timer.ResetTiemr();
        GameOverCheck();
    }

    private void GameOverCheck()
    {
        if (FrogLifes <= 0) OnLostAllLifes?.Invoke();
    }

    public void FrogReachedLeaf()
    {
        AddPointsForLeaf();
        UpdateProgress(PlayerPoints);
        timer.ResetTiemr();
    }
    
    private void AddPointsForLeaf()
    {
        _playerPoints += Convert.ToInt32((timer.LeftTime)) + pointsForLane;
        SetPlayerPoints();
    }

    public void AddpointsForLane()
    {
        _playerPoints += pointsForLane;
        SetPlayerPoints();
    }

    private void SetPlayerPoints()
    {
        PlayerPoints = _playerPoints;
        OnPointsRecived?.Invoke(PlayerPoints);
    }

    private void UpdateProgress(int pointsToPass)
    {
        _leafsReached ++;
        if (_leafsReached >= _leafsReachedToCompleteLevel)
        {
            PauseGame();
            OnLevelComplete?.Invoke();
            _levelsComplete++;
            GameCompletitionCheck();
        }
    }

    private void GameCompletitionCheck()
    {
        if (_levelsComplete >= _gameLevelsToCompleteGame)
        {
            OnGameComplete?.Invoke();
        }
    }

    public void SetupNewLevel()
    {
        _leafsReached = 0;
        ReplenishHealth();
        timer.ResetTiemr();
        if (_levelsComplete < _gameLevelsToCompleteGame)
        {
            UnpauseGame();
        }
    }

    public void SetupNewGame()
    {
        _playerPoints = 0;
        _leafsReached = 0;
        _levelsComplete = 0;
        timer.ResetTiemr();
        SetPlayerPoints();
        UnpauseGame();
        ReplenishHealth();
    }
}
