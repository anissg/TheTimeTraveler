using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Era
{
    past,
    present
}

public class TimeTravel : MonoBehaviour
{
    [SerializeField] private DigitalGlitch glitchEffect;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject past;

    private Era era = Era.present;

    void Start()
    {
        
    }

    void Update()
    {
        glitchEffect.intensity = Mathf.Max(0f, glitchEffect.intensity - 0.01f);
        
        if (Input.GetButtonUp("Fire1") && era == Era.present)
        {
            glitchEffect.intensity = 0.8f;
            
            present.SetActive(false);
            past.SetActive(true);
            era = Era.past;
        }

        if (Input.GetButtonUp("Fire2") && era == Era.past)
        {
            glitchEffect.intensity = 0.8f;

            present.SetActive(true);
            past.SetActive(false);
            era = Era.present;
        }
    }
}
