using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour
{
    public GameObject door;
    public bool hideDoor = false;
    
    public GameObject monster;
    public float attackDelay = 10f;
    public string attackAnimationName = "";

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

        yield return new WaitForSeconds(attackDelay);

        if (monster != null)
        {
            Animator anim = monster.GetComponentInChildren<Animator>();
            if (anim != null)
            {
                anim.Play(attackAnimationName, 0, 0f);
            }
        }
    }
}