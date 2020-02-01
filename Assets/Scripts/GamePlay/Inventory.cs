using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private GameObject _tree;

    public void AddTree(GameObject tree) {
        _tree = tree;
        _tree.SetActive(false);
    }

    private void Update() {
        if (_tree == null) return;
        if (Input.GetKeyDown(KeyCode.R)) {
            _tree.SetActive(true);
            _tree.transform.position = transform.position;
        }
    }
}