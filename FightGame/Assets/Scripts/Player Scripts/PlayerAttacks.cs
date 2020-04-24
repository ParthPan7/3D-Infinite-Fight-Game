using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum ComboState
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}
public class PlayerAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private MyCharacterAnimations animations;
    private bool activateTimerToReset;

    private float default_combo_timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    void Awake()
    {
        animations = GetComponentInChildren<MyCharacterAnimations>();
        
    }
    private void Start()
    {
        current_Combo_Timer = default_combo_timer;
        current_Combo_State = ComboState.NONE;
    }
    // Update is called once per frame
    private void Update()
    {
        Attacks();
        ResettingComboStates();
    }
    void Attacks()
    {
        if (Input.GetKeyDown(KeyCode.Z)){

            if (current_Combo_State == ComboState.PUNCH3 || current_Combo_State == ComboState.KICK1 || current_Combo_State== ComboState.KICK2) {
                return;
            }
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_combo_timer;
            if (current_Combo_State == ComboState.PUNCH1) {
                animations.Punch_1_Anim();
            }
            if (current_Combo_State == ComboState.PUNCH2) {
                animations.Punch_2_Anim();
            }

            if (current_Combo_State == ComboState.PUNCH3)
            {
                animations.Punch_3_Anim();
            }
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            if (current_Combo_State == ComboState.KICK2 || current_Combo_State == ComboState.PUNCH3) {
                return;
            }

            if (current_Combo_State == ComboState.NONE || current_Combo_State == ComboState.PUNCH1 || current_Combo_State == ComboState.PUNCH2) {
                current_Combo_State = ComboState.KICK1;
            } else if (current_Combo_State == ComboState.KICK1) {
                current_Combo_State++;
            }
            activateTimerToReset = true;
            current_Combo_Timer = default_combo_timer;

            if(current_Combo_State == ComboState.KICK1){
                animations.Kick_1_Anim();
               
            }
            if (current_Combo_State == ComboState.KICK2) {
                animations.Kick_2_Anim();
            }
        }
    }

    void ResettingComboStates() {
        if (activateTimerToReset) {
            current_Combo_Timer = current_Combo_Timer - Time.deltaTime;
        }
        if (current_Combo_Timer <= 0f) {
            current_Combo_State = ComboState.NONE;
            activateTimerToReset = false;
        }
    }
}
