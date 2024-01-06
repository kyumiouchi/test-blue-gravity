using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayController : MonoBehaviour
{
    private const float _secondsInDay = 60 * 60 * 24;

    [SerializeField] private Color _nightLightColor;
    [SerializeField] private AnimationCurve _nightTimeCurve;
    [SerializeField] private Color _dayLightColor;

    [SerializeField]
    private TextMeshProUGUI _txtDayTime;

    [SerializeField] private float _timeScale = 60f;
    [SerializeField] private Light2D _globalLight;
    private float _currentTime;
    private int _currentDay = 1;

    private void Start()
    {
        _currentTime = 6 * 60 * 60; // 6am
    }

    float Hours
    {
        get { return _currentTime / 3600f; }
    }
    float Minutes
    {
        get { return _currentTime % 3600f / 60; }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime * _timeScale;
        int hours = (int)Hours;
        int munites = (int)Minutes;
        _txtDayTime.text = "Day "+ _currentDay + " "+ hours.ToString("00") + ":" + munites.ToString("00");
        
        float valueCurve = _nightTimeCurve.Evaluate(Hours);
        Color color = Color.Lerp(_dayLightColor, _nightLightColor, valueCurve);
        _globalLight.color = color;
        if (_currentTime > _secondsInDay)
        {
            AddNextDay();
        }
    }

    private void AddNextDay()
    {
        _currentTime = 0;
        _currentDay++;
    }
}
