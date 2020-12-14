using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    [SerializeField] private List<LilyLeaf> lilyLeavesList;

    public void ResetZones()
    {
        foreach (LilyLeaf lily in lilyLeavesList)
        {
            lily.Reset();
        }
    }
}
