using UnityEngine;

public class CutMushroom : MonoBehaviour
{
   [SerializeField] private AudioClip mushroomCut;
   [SerializeField] private GameObject cutMushroom;
   [SerializeField] private GameObject wallMushroom;
   //[SerializeField] private AudioSource audioSource;


   private bool isCut = false;

   void Start()
   {
      if (cutMushroom != null)
      {
         cutMushroom.SetActive(false);
      }
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      if (isCut)
      {
         return;
      }

      if (collision.gameObject.CompareTag("Knife"))
      {
         MushroomCut();
      }
   }
   
   private void MushroomCut()
   {
      isCut = true;
      
      if (mushroomCut != null)
      {
         //audioSource.PlayOneShot(mushroomCut);
      }
      
      if (cutMushroom != null)
      {
         cutMushroom.SetActive(true);
      }
      
      if (wallMushroom != null)
      {
         wallMushroom.SetActive(false);
      }
      else
      {
         gameObject.SetActive(false);
      }
   }
}
