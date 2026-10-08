using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
public class SlotManager : MonoBehaviour
{
    private bool trigger = false;

    [SerializeField] public TextMeshPro slot1;
    [SerializeField] int slot1Ans;
    int slot1Num = 0;

    [SerializeField] public TextMeshPro slot2;
    [SerializeField] int slot2Ans;
    int slot2Num = 0;

    [SerializeField] public TextMeshPro slot3;
    [SerializeField] int slot3Ans;
    int slot3Num = 0;

    [SerializeField] public TextMeshPro slot4;
    [SerializeField] int slot4Ans;
    int slot4Num = 0;

    [SerializeField] public Animator anim;

    public GameObject knife;


    private void Start()
    {
        anim = GetComponent<Animator>();

        slot1.text = slot1Num.ToString();
        slot2.text = slot2Num.ToString();
        slot3.text = slot3Num.ToString();
        slot4.text = slot4Num.ToString();
    }
    void Update()
    {

        //Check if lock is correct
        if (slot1Num == slot1Ans  && slot2Num == slot2Ans && slot3Num == slot3Ans && slot4Num == slot4Ans && trigger == false)
        {
            
            anim.Play("Armature|ArmatureAction", 0, 0.0f);

            trigger = true;
            knife.SetActive(true);

        }
    }

    public void MoveSlot1()
    {
        if (trigger == false)
        {
            slot1Num++;
            slot1.text = slot1Num.ToString();

            
            if (slot1Num > 9)
            {
                slot1Num = 0;
            }



        }
    }

    public void MoveSlot2()
    {
        if (trigger == false)
        {
            slot2Num++;
            slot2.text = slot2Num.ToString();

            
            if (slot2Num > 9)
            {
                slot2Num = 0;
            }



        }
    }

    public void MoveSlot3()
    {
        if (trigger == false)
        {
            slot3Num++;
            slot3.text = slot3Num.ToString();

            
            if (slot3Num > 9)
            {
                slot3Num = 0;
            }



        }
    }

    public void MoveSlot4()
    {
        if (trigger == false)
        {
            slot4Num++;
            slot4.text = slot4Num.ToString();

            
            if (slot4Num > 9)
            {
                slot4Num = 0;
            }

        }
    }
}
