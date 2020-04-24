using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivateDelegation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;
    public float stand_Up_Timer = 2f;

    private MyCharacterAnimations MyCharacterAnimations;

    private AudioSource audioSource;

    public AudioClip whoosh_sound, fall_sound, ground_Hit_Sound, dead_Sound;
    private EnemyMovements enemyMovements;
    private CameraShake cameraShake;

    private void Awake()
    {
        MyCharacterAnimations = GetComponentInChildren<MyCharacterAnimations>();

        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG)) {
            enemyMovements = GetComponentInParent<EnemyMovements>();
        }
        cameraShake = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<CameraShake>();
        
    }
    void left_Arm_Attack_Point_On() {

        left_Arm_Attack_Point.SetActive(true);
    }

    void left_Arm_Attack_Point_Off() {

        if (left_Arm_Attack_Point.activeInHierarchy) {
            left_Arm_Attack_Point.SetActive(false);
        }
    }
    void right_Arm_Attack_Point_On()
    {

        right_Arm_Attack_Point.SetActive(true);
    }

    void right_Arm_Attack_Point_Off()
    {

        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }

    void left_Leg_Attack_Point_On()
    {

        left_Leg_Attack_Point.SetActive(true);
    }

    void left_Leg_Attack_Point_Off()
    {

        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }
    void right_Leg_Attack_Point_On()
    {

        right_Leg_Attack_Point.SetActive(true);
    }

    void right_Leg_Attack_Point_Off()
    {

        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }

    void Tag_left_Leg() {
        left_Leg_Attack_Point.tag = Tags.LEFT_LEG_TAG;
    }
    void Untag_left_Leg() {
        left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }
    void Tag_left_Arm() {
        left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void Untag_left_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void  Attack_Sound() {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_sound;
        audioSource.Play();
    }

    void CharacterDiedSound() {
        audioSource.volume = 1f;
        audioSource.clip = dead_Sound;
        audioSource.Play();
    }

    void Enemy_KnockDown() {
        audioSource.clip = fall_sound;
        audioSource.Play();
    }

    void Enemy_HitSound() {
        audioSource.clip = ground_Hit_Sound;
        audioSource.Play();
    }

    void DisableMovement() {
        enemyMovements.enabled = false;
        transform.parent.gameObject.layer = 0;
    }

    void Enablemovements()
    {

        enemyMovements.enabled = true;
        transform.parent.gameObject.layer = 10;
    }

    void ShakeCameraOnFall() {

        cameraShake.ShouldShake = true;
    }

    void EntityDied() {
        
        Invoke("deactivateGameObject", 2f);
    }

    void deactivateGameObject() {
        EnemyManager.instance.spwanEnemy();
        gameObject.SetActive(false);
    }
}
