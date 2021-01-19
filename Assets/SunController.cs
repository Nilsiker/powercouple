using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{

    [SerializeField] [Range(0, 23)] int hours = 12;
    [SerializeField] [Range(0, 59)] int minutes = 0;
    [SerializeField] [Range(0, 59)] int seconds = 0;

    [SerializeField] float timeSpeedModifier = 1;
    [SerializeField] Light sun;

    float tickTime = 0;

    private void Update()
    {
        tickTime += Time.deltaTime * timeSpeedModifier;
        print(tickTime);
        while (tickTime > 1)
        {
            Tick();
            tickTime--;
        }
    }

    private void Tick()
    {
        int totalSeconds = TotalSeconds() + 1;
        seconds = totalSeconds % 60;
        minutes = (totalSeconds / 60) % 60;
        hours = (totalSeconds / 3600) % 24;

        SetSunPosition();
        UpdateLighting();

    }

    private void UpdateLighting()
    {
        float c = Mathf.Max((Mathf.Abs(TotalSeconds() - 43200f)) / 86400f);
        print(c);
        RenderSettings.fogColor = new Color();
        RenderSettings.fogDensity = c;
    }

    private void SetSunPosition()
    {
        float x = (((float)TotalSeconds() / 86400f) * 360) - 90;
        sun.transform.eulerAngles = new Vector3(x, 0, 0);
    }

    private int TotalSeconds()
    {
        return hours * 3600 + minutes * 60 + seconds;
    }

    private void OnValidate()
    {
        SetSunPosition();
    }
}
