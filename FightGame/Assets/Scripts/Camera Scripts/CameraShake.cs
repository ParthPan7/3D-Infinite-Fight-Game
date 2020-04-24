using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool shouldShake;
    private float initialDuration;

    private Vector3 Startposition;
    // Start is called before the first frame update
    void Start() {
        Startposition = transform.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        Shake();
    }

    void Shake() {
        if (shouldShake) {
            if (duration > 0f)
            {
                transform.localPosition = transform.localPosition + power * Random.insideUnitSphere;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = Startposition;
            }
        }
    }


    public bool ShouldShake{
        get
        {

            return shouldShake;
        }
        set {
            shouldShake = value;
        }
    }
}
