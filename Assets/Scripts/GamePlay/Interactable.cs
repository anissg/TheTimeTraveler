using System;
using UnityEngine;

public class Interactable : MonoBehaviour {
    private bool _inRange;
    private Inventory _inventory;

    private void Update() {
        if (!_inRange) return;
        if (Input.GetKeyDown(KeyCode.E)) {
            if (_inventory) _inventory.AddTree(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _inRange = true;
        _inventory = other.GetComponent<Inventory>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        _inRange = false;
        _inventory = other.GetComponent<Inventory>();
    }
}