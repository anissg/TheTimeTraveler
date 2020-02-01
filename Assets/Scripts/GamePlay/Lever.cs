using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    [SerializeField] private DigitalGlitch glitchEffect;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject past;

    private Era era = Era.present;
    private bool playerInRange = false;

    void Start() { }

    void Update() {
        glitchEffect.intensity = Mathf.Max(0f, glitchEffect.intensity - 0.01f);

        if (!playerInRange) return;
        
        if (Input.GetKeyDown(KeyCode.E)) {
            glitchEffect.intensity = 0.8f;
            present.SetActive(!present.activeSelf);
            past.SetActive(!past.activeSelf);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        playerInRange = false;
    }
}