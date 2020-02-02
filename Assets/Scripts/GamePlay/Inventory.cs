using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject _tree;
    private Collision col;

    private void Start() {
        col = GetComponent<Collision>();
    }

    public void AddTree(GameObject tree) {
        _tree = tree;
        tree.GetComponent<Tree>().Deactivate();
    }

    private void Update() {
        if (_tree == null) return;
        if (Input.GetKeyDown(KeyCode.R) && col.onGround) {
            _tree.transform.position = transform.position;
            _tree.SetActive(true);
            _tree = null;
        }
    }
}