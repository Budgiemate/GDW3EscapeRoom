using UnityEngine;
using UnityEngine.UI;

public class gunshot : MonoBehaviour
{
    [SerializeField] private AudioClip gunShot;
    [SerializeField] private AudioSource audioSource;
    public float maxDistance = 50f;
    public ToggleGrabbable key;
    public GameObject electricity;
    
    public void shoot()
    {
        
        audioSource.PlayOneShot(gunShot);
        Vector3 origin = transform.position;
        Vector3 direction = transform.right;
        
        RaycastHit hitInfo;

        if (Physics.Raycast(origin, direction, out hitInfo, maxDistance))
        {
            if (hitInfo.collider.CompareTag("box"))
            {
                Destroy(hitInfo.collider.gameObject);
                Destroy(electricity);
                key.SetGrabbable(true);
            }
        }

        Debug.DrawRay(origin, direction * maxDistance, Color.red);
    }
}
