using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Death"))) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}