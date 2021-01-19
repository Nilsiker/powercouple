using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{

    [Range(0, 10)] [SerializeField] float rainIntensity = 1f;
    [Range(0, 10)] [SerializeField] float windStrength = 1f;
    [Tooltip("Wind direction is rotated around Y axis. 0 means the wind is parallel the positive Z-axis.")]
    [Range(0, 360)] [SerializeField] float windDirection;
    [Range(0, 10)] [SerializeField] float mistIntensity = 1f;

    [SerializeField] ParticleSystem rain;
    [SerializeField] ParticleSystem wind;
    //[SerializeField] ParticleSystem mist;


    private void Update(){
        // TODO dont do this...
        transform.position=GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void SetWeather(WeatherData data)
    {
        // TODO implement, update all values like OnValidate
    }

    private void OnValidate()
    {
        var rainEmission = rain.emission;
        var rainVelocity = rain.velocityOverLifetime;
        var windVelocity = wind.velocityOverLifetime;
        var windEmission = wind.emission;
        var windShape = wind.shape;

        float x = Mathf.Sin(Mathf.Deg2Rad * windDirection);
        float z = Mathf.Cos(Mathf.Deg2Rad * windDirection);
        
        windVelocity.x = x * 30;
        windVelocity.z = z * 30;
        windShape.rotation = new Vector3(-90,windDirection,0); 
        windEmission.rateOverTime = windStrength;
        
        rainEmission.rateOverTime = rainIntensity * 100;
        rainVelocity.x = x * 5 * windStrength;
        rainVelocity.z = z * 5 * windStrength;

    }
}
