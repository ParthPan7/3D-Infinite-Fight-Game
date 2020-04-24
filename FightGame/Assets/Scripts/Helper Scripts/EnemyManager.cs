using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField]
    private GameObject enemyprefab;
    
    void Awake()
    {
        if (instance == null)
            instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        spwanEnemy();
    }
    public void spwanEnemy() {
        Instantiate(enemyprefab,transform.position,Quaternion.identity);
    }
}
