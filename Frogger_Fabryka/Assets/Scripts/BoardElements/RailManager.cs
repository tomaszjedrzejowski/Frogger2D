using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    [SerializeField] private List<RailController> railsList = new List<RailController>();
    
    public void RiseRailsDifficulty()
    {
        foreach (RailController rail in railsList)
        {
            rail.RiseDifficulty();
        }
    }

    public void ResetRailsDifficulty()
    {
        foreach (RailController rail in railsList)
        {
            rail.ResetDifficulty();
        }
    }
}
