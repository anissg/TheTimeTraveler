using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairFracture : MonoBehaviour {
    public int numberOfParticles;
    public GameObject timeFracture;

    private int _particlesGathered;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Particle"))) {
            _particlesGathered++;
            Destroy(other.gameObject);
        }

        if (_particlesGathered == numberOfParticles) {
            Destroy(timeFracture);
        }
    }
}