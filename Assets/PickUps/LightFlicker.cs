using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float lightIntensity; 
    public float speed; 
    public UnityEngine.Rendering.Universal.Light2D light2D;

    public float maxIntensity;
    public float minIntensity;

    public bool swithLight;

    public bool bounce;
    public float amount;

    private void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        lightIntensity = light2D.intensity;
    }

    private void Update()
    {

        LightFlickerLight();

    }


    public void LightFlickerLight()
    {
        if (lightIntensity >= maxIntensity)
        {
            swithLight = false;
        }
        else if (lightIntensity <= minIntensity)
        {
            swithLight = true;
        }

        if (swithLight)
        {
            lightIntensity += speed * Time.deltaTime;
            transform.position += Vector3.up / 6 * Time.deltaTime;
        }
        else if (!swithLight)
        {
            lightIntensity -= speed * Time.deltaTime;
            transform.position += Vector3.down / 6 * Time.deltaTime;
        }

        light2D.intensity = lightIntensity;
    }

}