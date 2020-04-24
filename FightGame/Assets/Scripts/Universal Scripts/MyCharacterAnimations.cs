using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterAnimations : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void WalkAnim(bool action) {
        animator.SetBool(AnimationTags.MOVEMENT,action);
    }

    public void Punch_1_Anim()
    {
        animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }
    public void Punch_2_Anim()
    {
        animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }
    public void Punch_3_Anim()
    {
        animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }


    public void Kick_1_Anim()
    {
        animator.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick_2_Anim()
    {
        animator.SetTrigger(AnimationTags.KICK_2_TRIGGER);
        
    }

    //Enemy Attacks and animations
    public void EnemyAttacks(int attack_token) {
        if (attack_token == 0) {
            animator.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }

        if (attack_token == 1){
            animator.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }

        if (attack_token == 2){
            animator.SetTrigger(AnimationTags.ATTACK_3_TRIGGER);
        }

    }
    public void PlayIdleAnimation() {

        animator.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown() {

        animator.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void StandUp() {

        animator.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }

    public void Hit(){
        animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death() {
        animator.SetTrigger(AnimationTags.DEATH_TRIGGER);

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
