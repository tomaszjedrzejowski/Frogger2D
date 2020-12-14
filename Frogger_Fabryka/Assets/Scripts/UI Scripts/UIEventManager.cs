using UnityEngine;

public class UIEventManager : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private Timer timer;
    [SerializeField] private LevelSummaryMenu levelSummaryMenu;
    [SerializeField] private GameSummaryMenu gameSummaryMenu;
    [SerializeField] private OptionsMenu optionsMenu;
    [SerializeField] private LifesLeftVisualisation lifeDisplay;
    [SerializeField] private TextDisplay scoreDisplay;
    [SerializeField] private TextDisplay timerDisplay;

    private void Start()
    {
        gameMaster.OnLevelComplete += HandleLevelSummary;
        gameMaster.OnGameComplete += HandleGameSummary;
        gameMaster.OnLostAllLifes += HandleGameSummary;
        gameMaster.OnPointsRecived += scoreDisplay.UpdateDisplay;
        gameMaster.OnLifesAmountChange += lifeDisplay.UpdateLifeAmount;
        timer.OnTimeUpdate += timerDisplay.UpdateDisplay;
        
        optionsMenu.OnOpenMenu += gameMaster.PauseGame;
        optionsMenu.OnCloseMenu += gameMaster.UnpauseGame;               
        levelSummaryMenu.OnNewLevelClicked += eventManager.HandleNewLevel;
        gameSummaryMenu.OnNewGameClick += eventManager.HandleNewGame;

    }

    private void OnDisable()
    {
        gameMaster.OnLevelComplete -= HandleLevelSummary;
        gameMaster.OnGameComplete -= HandleGameSummary;
        gameMaster.OnLostAllLifes -= HandleGameSummary;
        gameMaster.OnPointsRecived -= scoreDisplay.UpdateDisplay;
        gameMaster.OnLifesAmountChange -= lifeDisplay.UpdateLifeAmount;
        timer.OnTimeUpdate -= timerDisplay.UpdateDisplay;


        optionsMenu.OnOpenMenu -= gameMaster.PauseGame;
        optionsMenu.OnCloseMenu -= gameMaster.UnpauseGame;
        levelSummaryMenu.OnNewLevelClicked -= eventManager.HandleNewLevel;
        gameSummaryMenu.OnNewGameClick -= eventManager.HandleNewGame;
    }

    private void HandleLevelSummary()
    {
        int pointValue = gameMaster.PlayerPoints;
        levelSummaryMenu.LevelSummary(pointValue);
    }

    private void HandleGameSummary() 
    {
        int pointValue = gameMaster.PlayerPoints;
        gameSummaryMenu.GameSummary(pointValue);
    }
}
