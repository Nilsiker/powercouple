using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Our Assets/Weather Data")]
public class WeatherData : ScriptableObject
{
    [Range(0, 10)] public float rainIntensity;
    [Range(0, 10)] public float windStrength;
    [Range(0, 360)] public float windDirection;
    [Range(0, 10)] public float mistIntensity;
}
