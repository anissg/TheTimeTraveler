using UnityEngine;

public class Lever : MonoBehaviour {
    [SerializeField] private DigitalGlitch glitchEffect;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject past;
    [SerializeField] private Sprite offTexture, onTexture;

    private bool _playerInRange;
    private bool _leverState;
    private SpriteRenderer _spriteRenderer;

    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        glitchEffect.intensity = Mathf.Max(0f, glitchEffect.intensity - 0.01f);

        if (!_playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E)) {
            _leverState = !_leverState;
            _spriteRenderer.sprite = _leverState ? onTexture : offTexture;

            glitchEffect.intensity = 0.8f;
            present.SetActive(!present.activeSelf);
            past.SetActive(!past.activeSelf);
            TimeManager.GetInstance().SwitchEra();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        _playerInRange = false;
    }
}