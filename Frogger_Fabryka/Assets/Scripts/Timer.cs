using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float roundTime = 20;

    public float LeftTime { get; private set; }
    private float _timeLeft;

    public Action OnTimeOut;
    public Action<float> OnTimeUpdate;

    void Start()
    {
        ResetTiemr();
    }

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        LeftTime = Convert.ToInt32(_timeLeft);
        OnTimeUpdate?.Invoke(LeftTime);
        CheckTimeOut();
    }

    private void CheckTimeOut()
    {
        if (_timeLeft <= 0)
        {
            OnTimeOut?.Invoke();
            ResetTiemr();
        }
    }

    public void ResetTiemr()
    {
        _timeLeft = roundTime;
    }
}
