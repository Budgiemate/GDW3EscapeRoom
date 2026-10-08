using UnityEngine;
public class OSCtest : MonoBehaviour
{

    private Renderer _renderer;
    private Material _material;
    public Light light;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _material.EnableKeyword("_EMISSION");
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
            Color finalColor = Color.cyan * (1 + value * 100);
            _material.SetColor("_EmissionColor", finalColor);
            DynamicGI.SetEmissive(_renderer, finalColor);
        }
        else
        {
            light.intensity = 0.0f;
            Color finalColor = Color.cyan;
            _material.SetColor("_EmissionColor", finalColor);
            DynamicGI.SetEmissive(_renderer, finalColor);
        }
    }
}
