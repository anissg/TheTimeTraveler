using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Era
{
    past,
    present,
    future
}

public class TimeTravel : MonoBehaviour
{
    [SerializeField] private DigitalGlitch glitchEffect;
    [SerializeField] private GameObject past;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject future;

    private Era era = Era.present;

    void Update()
    {
        glitchEffect.intensity = Mathf.Max(0f, glitchEffect.intensity - 0.01f);
        
        if (Input.GetButtonUp("Fire1"))
        {
            if (era == Era.future)
            {
                glitchEffect.intensity = 0.8f;
                past.SetActive(false);
                present.SetActive(true);
                future.SetActive(false);
                era = Era.present;
            }
            else if (era == Era.present)
            {
                glitchEffect.intensity = 0.8f;
                past.SetActive(true);
                present.SetActive(false);
                future.SetActive(false);
                era = Era.past;
            }
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
