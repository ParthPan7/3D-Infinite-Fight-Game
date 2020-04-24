using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private MyCharacterAnimations mycharacterAnimationsScript;
    private EnemyMovements enemyMovements;

    private bool characterDied;
    public bool is_Player;
    private HealthUI healthUI;
    private void Awake()
    {
        mycharacterAnimationsScript = GetComponentInChildren<MyCharacterAnimations>();
        if (is_Player) {
            healthUI = GetComponent<HealthUI>();
        }
    }
    public void ApplyDamage(float damage,bool knockDown) {
        if (characterDied)
            return;
        health -= damage;

        if (is_Player) { healthUI.DisplayHealth(health); }
       

        if (health <= 0f) {

            mycharacterAnimationsScript.Death();
            characterDied = true;

            if (is_Player)
            {
                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovements>().enabled = false;
            }

            else {

            }
            return;
        }

        if (!is_Player) {
            if (knockDown)
            {
                if (Random.RandomRange(0, 2) > 0)
                {
                    mycharacterAnimationsScript.KnockDown();
                    print("Knock Down");
                }

                
            }

            else {
                if (Random.RandomRange(0, 3) > 1)
                {
                    mycharacterAnimationsScript.Hit();
                    print("Hit");
                }
            }
        }
    }
}
