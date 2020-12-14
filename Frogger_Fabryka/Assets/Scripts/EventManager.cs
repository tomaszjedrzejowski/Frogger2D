using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    [SerializeField] private FrogController frogController;
    [SerializeField] private Timer timer;
    [SerializeField] private UIEventManager UIManager;
    [SerializeField] private RailManager railManager;
    [SerializeField] private ScoringZone scoringZone;

    void Start()
    {
        gameMaster.OnLevelComplete += railManager.RiseRailsDifficulty;
        gameMaster.OnPauseStatusChange += frogController.CheckAbleToMove;

        frogController.OnHigherLaneReach += gameMaster.AddpointsForLane;
        frogController.OnLilyLeafReach += gameMaster.FrogReachedLeaf;
        frogController.OnFrogKilled += gameMaster.HandleFrogDeath;

        timer.OnTimeOut += frogController.RunsOutOfTime;
    }

    private void OnDisable()
    {
        gameMaster.OnLevelComplete -= railManager.RiseRailsDifficulty;
        gameMaster.OnPauseStatusChange -= frogController.CheckAbleToMove;

        frogController.OnHigherLaneReach -= gameMaster.AddpointsForLane;
        frogController.OnLilyLeafReach -= gameMaster.FrogReachedLeaf;
        frogController.OnFrogKilled -= gameMaster.HandleFrogDeath;

        timer.OnTimeOut -= frogController.RunsOutOfTime;
    }

    public void HandleNewLevel()
    {
        frogController.SetupNewLevel();
        gameMaster.SetupNewLevel();
        scoringZone.ResetZones();
    }

    public void HandleNewGame()
    {
        frogController.SetupNewLevel();
        gameMaster.SetupNewGame();
        railManager.ResetRailsDifficulty();
        scoringZone.ResetZones();
    }
}
