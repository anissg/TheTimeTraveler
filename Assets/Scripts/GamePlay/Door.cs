using UnityEngine;

public class Door : MonoBehaviour {
    public GameObject target;

    private bool inRange;
    private GameObject _player;

    private void Update() {
        if (!inRange) return;
        if (Input.GetKeyDown(KeyCode.W)) {
            _player.transform.position = target.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        inRange = true;
        _player = col.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        inRange = false;
    }
}
