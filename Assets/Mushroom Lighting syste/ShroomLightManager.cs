using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShroomLightManager : MonoBehaviour
{
    private const int MAX_LIGHTS = 16;
    public float mindist;
    public float maxdist;
    
    private Vector4[] positionsArray = new Vector4[MAX_LIGHTS];
    private MushroomLightPoint[] activeLights;
    
    public TMP_Text[] texts;
    [Header("Sprite Configuration")]
    public SpriteRenderer[] hiderSprites; 

    private void Start()
    {
        
        if (hiderSprites == null || hiderSprites.Length == 0)
        {
            FindSprites();
        }
    }

    private void Update()
    {
        //Shroompooints
        activeLights = Object.FindObjectsByType<MushroomLightPoint>(FindObjectsSortMode.None);
        int count = Mathf.Min(activeLights.Length, MAX_LIGHTS);

        // Texts
        for (int j = 0; j < texts.Length; j++)
        {
            if (texts[j] == null) continue;

            float greatest = CalculateGreatestAlpha(texts[j].transform.position, count);
            
            Color color = texts[j].color;
            color.a = greatest;
            texts[j].color = color;
        }

        // SpriteRenderers
        for (int k = 0; k < hiderSprites.Length; k++)
        {
            if (hiderSprites[k] == null) continue;

            float greatest = CalculateGreatestAlpha(hiderSprites[k].transform.position, count);
            
            Color color = hiderSprites[k].color;
            color.a = greatest;
            hiderSprites[k].color = color;
        }
    }

    
    private float CalculateGreatestAlpha(Vector3 targetPosition, int count)
    {
        float greatest = 0f;
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = activeLights[i].transform.position;
            float distance = activeLights[i].RevealDistance;
            positionsArray[i] = new Vector4(pos.x, pos.y, pos.z, distance);
            
            float lerp = Mathf.InverseLerp(maxdist, mindist, (pos - targetPosition).magnitude);
            if (lerp > greatest)
            {
                greatest = lerp;
            }
        }
        return greatest;
    }

    public void FindSprites()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("shroomhider");
        System.Collections.Generic.List<SpriteRenderer> spriteList = new System.Collections.Generic.List<SpriteRenderer>();

        foreach (GameObject obj in taggedObjects)
        {
            if (obj.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
            {
                spriteList.Add(sr);
            }
        }
        hiderSprites = spriteList.ToArray();
    }
}
