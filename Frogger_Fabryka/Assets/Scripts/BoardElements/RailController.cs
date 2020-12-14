using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{      
    [SerializeField] private CarConfig obstacleConfig;
    [SerializeField] private List<Transform> spawnPointsList = new List<Transform>();

    [HideInInspector] public List<ObstacleController> ObstList = new List<ObstacleController>();
    [HideInInspector] public int _levelDifficulty;

    public void Start()
    {
        InstantiatePrefabs();
        _levelDifficulty = 0;
    }

    public virtual void InstantiatePrefabs()
    {
        foreach (Transform spawnPoint in spawnPointsList)
        {
            ObstacleController obstacle = Instantiate(obstacleConfig.ObstPrefab, spawnPoint);
            ObstList.Add(obstacle);
            SetUpParams(obstacle);
        }
    }

    public virtual void SetUpParams(ObstacleController obstacle)
    {
        (obstacle.IsLeathal ,obstacle.Speed, obstacle.FaceLeft) = (obstacleConfig.IsLeathal, obstacleConfig.SpeedArray[_levelDifficulty], obstacleConfig.FaceLeft[_levelDifficulty]);
    }
    
    public void RiseDifficulty()
    {
        if(_levelDifficulty <=1) _levelDifficulty++;

        foreach (ObstacleController obstacle in ObstList)
        {
            SetUpParams(obstacle);
        }
    }

    public void ResetDifficulty()
    {
        _levelDifficulty = 0;
        foreach (ObstacleController obstacle in ObstList)
        {
            SetUpParams(obstacle);
        }
    }

}
