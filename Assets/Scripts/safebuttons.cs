using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class safebuttons : MonoBehaviour{
    
    [SerializeField] private AudioClip beep;
    [SerializeField] private AudioSource audioSource;
    public List<int> presses = new List<int>();
    public GameObject gun;
    public GameObject closedsafe;
    public GameObject opensafe;
    
    public void pressButton(int number)
    {
        audioSource.PlayOneShot(beep);
        List<int> answer = new List<int>() {  4, 2, 9,7 };
        presses.Add(number);
        if (presses.Count >= 4 && presses.TakeLast(4).ToList().SequenceEqual(answer))
        {
            opensafe.SetActive(true);
            gun.SetActive(true);
            closedsafe.SetActive(false);
        }
    }
}
