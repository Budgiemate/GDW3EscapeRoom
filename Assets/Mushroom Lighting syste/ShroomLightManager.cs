using TMPro;
using UnityEngine;
using TMPro;

public class ShroomLightManager : MonoBehaviour
{
    
    private const int MAX_LIGHTS = 16;
    public float mindist;
    public float maxdist;
    
    private Vector4[] positionsArray = new Vector4[MAX_LIGHTS];
    private MushroomLightPoint[] activeLights;
    public TMP_Text[] texts;

    private void Update()
    {
        // find each shroompoitn
        activeLights = Object.FindObjectsByType<MushroomLightPoint>(FindObjectsSortMode.None);
        
        int count = Mathf.Min(activeLights.Length, MAX_LIGHTS);

        for (int j = 0; j < texts.Length; j++)
        {
            float greatest = 0;
            for (int i = 0; i < count; i++)
            {
                Vector3 pos = activeLights[i].transform.position;
                float distance = activeLights[i].RevealDistance;
                positionsArray[i] = new Vector4(pos.x, pos.y, pos.z, distance);
                float lerp = Mathf.InverseLerp(maxdist, mindist, (pos - texts[j].transform.position).magnitude);
                if (lerp > greatest)
                {
                    greatest = lerp;
                }
            }
            Color color = texts[j].color;
            color.a = greatest;
            texts[j].color = color;
        }
    }
}