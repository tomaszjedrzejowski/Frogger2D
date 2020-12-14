using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeRailController : RailController
{
    [SerializeField] private PlatformConfig platformConfig;
    [SerializeField] private List<Transform> shortSpawnPointsList;
    [SerializeField] private List<Transform> longSpawnPointsList;
    
    public override void InstantiatePrefabs()
    {
        foreach (Transform spawnPoint in shortSpawnPointsList)
        {
            ObstacleController obstacle = Instantiate(platformConfig.shortObstPrefab, spawnPoint);
            ObstList.Add(obstacle);
            SetUpParams(obstacle);
        }
        foreach (Transform spawnPoint in longSpawnPointsList)
        {
            ObstacleController obstacle = Instantiate(platformConfig.LongObstPrefab, spawnPoint);
            ObstList.Add(obstacle);
            SetUpParams(obstacle);
        }
    }
}
