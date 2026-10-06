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


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (trigger == false)
        {
            slot1.text = slot1Num.ToString();
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                slot1Num++;
                if (slot1Num > 9)
                {
                    slot1Num = 0;
                }

            }

            slot2.text = slot2Num.ToString();
            if ((Keyboard.current.digit2Key.wasPressedThisFrame))
            {
                slot2Num++;
                if (slot2Num > 9)
                {
                    slot2Num = 0;
                }
            }

            slot3.text = slot3Num.ToString();
            if ((Keyboard.current.digit3Key.wasPressedThisFrame))
            {
                slot3Num++;
                if (slot3Num > 9)
                {
                    slot3Num = 0;
                }
            }

            slot4.text = slot4Num.ToString();
            if ((Keyboard.current.digit4Key.wasPressedThisFrame))
            {
                slot4Num++;
                if (slot4Num > 9)
                {
                    slot4Num = 0;
                }
            }

            //Check if lock is correct
            if (slot1Num == slot1Ans && slot2Num == slot2Ans && slot3Num == slot3Ans && slot4Num == slot4Ans && trigger == false)
            {

                anim.Play("Armature|ArmatureAction", 0, 0.0f);

                trigger = true;


            }
        }
        
    }
}
