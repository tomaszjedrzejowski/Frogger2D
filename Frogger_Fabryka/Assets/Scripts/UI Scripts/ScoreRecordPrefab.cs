using UnityEngine;
using UnityEngine.UI;

public class ScoreRecordPrefab : MonoBehaviour
{
    [SerializeField] private Text rankText;
    [SerializeField] private Text scoreText;

    public void UpdateTextFields(int rank, int score)
    {
        rankText.text = rank.ToString() + ".";
        scoreText.text = score.ToString();
    }    
}
