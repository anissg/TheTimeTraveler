using System;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public bool _inRange;
    public Inventory _inventory;

    private void Update() {
        if (!_inRange) return;
        if (Input.GetKeyDown(KeyCode.E)) {
            if (_inventory) _inventory.AddTree(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _inRange = true;
        var inv = other.GetComponent<Inventory>();
        if (inv) {
            _inventory = inv;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        _inRange = false;
        var inv = other.GetComponent<Inventory>();
        if (inv) {
            _inventory = inv;
        }
    }
}