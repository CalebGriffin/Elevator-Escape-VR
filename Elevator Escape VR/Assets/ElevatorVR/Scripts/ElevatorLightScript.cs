using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLightScript : MonoBehaviour
{

    private IEnumerator LightLoop;
    [SerializeField] private List<Light> elevatorLights;

    private int getRandomInt(int min, int max)
    {

        if (min == max)
            return min;

        if(max < min)
        {
            int swap = min;
            min = max;
            max = swap;
        }

        return min + (int)((float)(max - min) * Random.Range(0.0f, 1.0f));

    }

    IEnumerator FlickeringTick(float minSeconds, float maxSeconds, float minIntensity, float maxIntensity, Color lightColor, float duration)
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));

            int flickerAmount = getRandomInt(3, 6);
            for (int i = flickerAmount; i > 0; i--)
            {
                setLights(lightColor, Random.Range(minIntensity, maxIntensity));
                yield return new WaitForSeconds(duration / (float)flickerAmount);
            }

            setLights(lightColor, 1.0f);

        }

    }

    public void setFlicker(float minSeconds, float maxSeconds, float minIntensity, float maxIntensity, Color lightColor, float duration)
    {

        if (LightLoop != null)
            StopCoroutine(LightLoop);

        LightLoop = FlickeringTick(minSeconds, maxSeconds, minIntensity, maxIntensity, lightColor, duration);
        StartCoroutine(LightLoop);

    }

    void setLights(Color lightColor, float intensity)
    {

        foreach (Light light in elevatorLights)
        {
            light.color = lightColor;
            light.intensity = intensity;
        }

    }

    public void resetLights()
    {
        if (LightLoop != null)
        {
            StopCoroutine(LightLoop);
            setLights(Color.white, 1.0f);
        }
    }

}
