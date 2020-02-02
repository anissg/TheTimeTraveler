using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    private bool inRange;
    private GameObject _player;

    private void Update() {
        if (!inRange) return;
        if (Input.GetButtonDown("Fire2")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
