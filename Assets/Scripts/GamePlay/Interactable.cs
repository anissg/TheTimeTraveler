using System;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public bool inRange;
    public Inventory inventory;

    private void Update() {
        if (!inRange) return;
        if (Input.GetButtonDown("Fire2")) {
            if (inventory) inventory.AddTree(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        inRange = true;
        var inv = other.GetComponent<Inventory>();
        if (inv) {
            inventory = inv;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        inRange = false;
    }
}