using UnityEngine;

public class OSCtest : MonoBehaviour
{

    private Renderer _renderer;
    private Material _material;
    public Light light;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        // Cache the components once on start instead of every time kick() runs
        _renderer = GetComponent<Renderer>();

        // Using .material creates a runtime clone you can safely modify
        _material = _renderer.material;

        // Force Unity to enable emission on this material at runtime
        _material.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kick(float value)
    {
        _renderer = GetComponent<Renderer>();
        if (Application.isPlaying)
        {
            _material = _renderer.material;
        }
        else
        {
            _material = _renderer.sharedMaterial;
        }
        if (value > 0)
        {
            light.intensity = value * 50.0f;
            Color finalColor = Color.white * (1 + value * 100);
            _material.SetColor("_EmissionColor", finalColor);
            DynamicGI.SetEmissive(_renderer, finalColor);
        }
        else
        {
            light.intensity = 0.0f;
            Color finalColor = Color.white;
            _material.SetColor("_EmissionColor", finalColor);
            DynamicGI.SetEmissive(_renderer, finalColor);
        }
    }
}
