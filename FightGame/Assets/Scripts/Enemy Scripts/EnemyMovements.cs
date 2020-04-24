using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    private MyCharacterAnimations EnemyAnim;
    private Rigidbody myBody;
    private float speed = 5f;
    private Transform playerTarget;

    private float attack_Distance = 1f;
    private float chase_Player_After_Attack_Distance = 1f;

    private float current_Attack_Time;
    private float Default_Attack_Time = 2f;

    private bool attackplayer, followplayer;


    // Start is called before the first frame update
    private void Start(){
        followplayer = true;
        current_Attack_Time = Default_Attack_Time;
    }
    
    void Awake(){
        EnemyAnim = GetComponentInChildren<MyCharacterAnimations>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    private void FixedUpdate(){
        FollowTargetPlayer();
    }
    // Update is called once per frame
    void Update(){
        Attack();
    }

    private void FollowTargetPlayer()
    {
        if (!followplayer)
            return;
        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance) {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;
            if (myBody.velocity.sqrMagnitude != 0)
            {
                EnemyAnim.WalkAnim(true);
                myBody.velocity = speed * myBody.velocity;
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance){

            myBody.velocity = Vector3.zero;
            EnemyAnim.WalkAnim(false);
            followplayer = false;
            attackplayer = true;
        }
    }

    private void Attack() {
        if (!attackplayer) {
            return;
        }

        current_Attack_Time = current_Attack_Time + Time.deltaTime;
        if (current_Attack_Time > Default_Attack_Time) {
            EnemyAnim.EnemyAttacks(UnityEngine.Random.Range(0,3));
            current_Attack_Time = 0f;
        }

        if (Vector3.Distance(transform.position,playerTarget.position) > attack_Distance+chase_Player_After_Attack_Distance) {
            attackplayer = false;
            followplayer = true;
        }
    }
}
