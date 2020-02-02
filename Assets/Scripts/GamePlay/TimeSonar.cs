using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSonar : MonoBehaviour
{
    [SerializeField] private GameObject shadowPresent;
    [SerializeField] private GameObject shadowPast;
    [SerializeField] private GameObject sonarShadow;
    [SerializeField] private float sonarDuration;
    [SerializeField] private GameObject sonar;
    private float currentDuration;
    private bool sonarState;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !sonarState && TimeManager.GetInstance().era == Era.Present)
        {
            sonarState = true;
            currentDuration = sonarDuration;
            sonarShadow.SetActive(true);
            sonar.SetActive(true);

            switch (TimeManager.GetInstance().era)
            {
                case Era.Past:
                    shadowPast.SetActive(false);
                    shadowPresent.SetActive(true);
                    break;
                case Era.Present:
                    shadowPast.SetActive(true);
                    shadowPresent.SetActive(false);
                    break;
            }
        }

        if (currentDuration > 0)
            currentDuration -= Time.deltaTime;
        else
        {
            sonar.SetActive(false);
            sonarShadow.SetActive(false);
            sonarState = false;
        }

    }
}
