using UnityEngine;

public class ShroomLightManager : MonoBehaviour
{
    
    private const int MAX_LIGHTS = 16; 

    private static readonly int GlobalRevealPositions = Shader.PropertyToID("_GlobalRevealPositions");
    private static readonly int GlobalRevealCount = Shader.PropertyToID("_GlobalRevealCount");

    private Vector4[] positionsArray = new Vector4[MAX_LIGHTS];
    private MushroomLightPoint[] activeLights;

    private void Update()
    {
        // find each shroompoitn
        activeLights = Object.FindObjectsByType<MushroomLightPoint>(FindObjectsSortMode.None);
        
        int count = Mathf.Min(activeLights.Length, MAX_LIGHTS);

        
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = activeLights[i].transform.position;
            float distance = activeLights[i].RevealDistance;
            
            positionsArray[i] = new Vector4(pos.x, pos.y, pos.z, distance);
        }

        //sends it to shaders
        Shader.SetGlobalVectorArray(GlobalRevealPositions, positionsArray);
        Shader.SetGlobalInt(GlobalRevealCount, count);
    }
}
