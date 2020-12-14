using UnityEngine;

[CreateAssetMenu(menuName = "Car Config")]
public class CarConfig : ScriptableObject
{
    public ObstacleController ObstPrefab;
    [SerializeField] private bool isLeathal;
    [SerializeField] private float[] speedArray;
    [SerializeField] private bool[] faceLeft;

    public bool IsLeathal { get { return isLeathal; } set { isLeathal = value; } }
    public float[] SpeedArray { get { return speedArray; } set { speedArray = value; } }
    public bool[] FaceLeft { get { return faceLeft; } set { faceLeft = value; } }
}