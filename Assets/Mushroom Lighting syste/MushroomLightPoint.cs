using UnityEngine;

public class MushroomLightPoint : MonoBehaviour
{
    [SerializeField] private float revealDistance = 10f;
    public float RevealDistance => revealDistance;

    private static readonly int GlobalRevealPosition = Shader.PropertyToID("_GlobalRevealPosition");
    private static readonly int GlobalRevealDistance = Shader.PropertyToID("_GlobalRevealDistance");

    private void Start()
    {
        //Set reveal circle
        Shader.SetGlobalFloat(GlobalRevealDistance, revealDistance);
    }

    private void Update()
    {
        //updates reveal ciurcle
        Shader.SetGlobalVector(GlobalRevealPosition, transform.position);
    }
}
