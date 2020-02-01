using UnityEngine;

public class Lever : MonoBehaviour {
    [SerializeField] private DigitalGlitch glitchEffect;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject past;
    [SerializeField] private Sprite offTexture, onTexture;

    private Era era = Era.present;
    private bool playerInRange = false;
    private bool leverState = false;
    private SpriteRenderer _spriteRenderer;

    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        glitchEffect.intensity = Mathf.Max(0f, glitchEffect.intensity - 0.01f);

        if (!playerInRange) return;
        
        if (Input.GetKeyDown(KeyCode.E)) {
            leverState = !leverState;
            _spriteRenderer.sprite = leverState ? onTexture : offTexture;
            
            glitchEffect.intensity = 0.8f;
            present.SetActive(!present.activeSelf);
            past.SetActive(!past.activeSelf);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        playerInRange = false;
    }
}