using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "0000";
    }

    public void UpdateDisplay(float points)
    {
        scoreText.text = points.ToString();
    }
}
