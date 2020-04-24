using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("DeActivateAfterProcess", timer);
    }

    // Update is called once per frame
    void DeActivateAfterProcess() {
        gameObject.SetActive(false);
    }
}
