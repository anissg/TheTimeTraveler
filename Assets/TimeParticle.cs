using UnityEngine;

public class TimeParticle : MonoBehaviour {
    public GameObject timeFracture;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Player")) {
            Destroy(timeFracture);
            Destroy(gameObject);
        }
    }
}
