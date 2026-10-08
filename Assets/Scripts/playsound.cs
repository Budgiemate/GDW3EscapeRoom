using UnityEngine;

public class playsound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;
    public void playSound()
    {
        audioSource.PlayOneShot(clip);
    }
}
