using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanGauge : MonoBehaviour
{
    private float power;
    public Rigidbody rb;
    public Slider slider;

    void Start()
    {
        power = 0;
        slider.value = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (power < 10)
            {
                power += 0.1f;
            }
        }

        Debug.Log(power);
        slider.value = power * 0.1f;
    }
}
