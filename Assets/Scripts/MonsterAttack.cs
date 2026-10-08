using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private bool hideDoor = false;

    [SerializeField] private GameObject monster;
    [SerializeField] private float attackDelay = 10f;
    [SerializeField] private string attackAnimationName = "";
    
    [SerializeField] private AudioClip idle;
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip doorsound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource monsterSource;

    private bool triggered = false;

    void Start()
    {
        if (monster != null)
        {
            monster.SetActive(false);
        }
        
        if (door != null)
        {
            door.SetActive(!hideDoor);
        }
    }
    
    public void TriggerTrap()
    {
        if (triggered)
        {
            return;
        }
        triggered = true;
        
        if (door != null)
        {
            door.SetActive(!hideDoor);
        }
        
        StartCoroutine(TrapSequence());
    }

    private IEnumerator TrapSequence()
    {
        if (monster != null)
        {
            monster.SetActive(true);
        }
        
        audioSource.PlayOneShot(doorsound);
        monsterSource.Play();        
        yield return new WaitForSeconds(attackDelay);

        if (monster != null)
        {
            Animator anim = monster.GetComponentInChildren<Animator>();
            if (anim != null)
            {
                audioSource.PlayOneShot(attack);
                anim.Play(attackAnimationName, 0, 0f);
            }
            
            yield return new WaitForSeconds(2.3f);
            SceneManager.LoadScene("TitleScreen");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
        {
            return;
        }

        if (other.CompareTag("Key"))
        {
            TriggerTrap();
        }
    }
}