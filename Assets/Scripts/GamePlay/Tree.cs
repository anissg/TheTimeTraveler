using UnityEngine;

public enum TreeState {
    None = 0,
    Baby = 1,
    Grownup = 2
}

public class Tree : MonoBehaviour, IPuzzleElement {
    public GameObject babyTree, grownupTree;
    public TreeState treeState;

    private Era _era;
    private GameObject _shadowTree;
    private Sprite babySprite, grownupSprite;
    private Vector3 _offset;

    void Start() {
        _offset = TimeManager.GetInstance().Offset;
        _era = TimeManager.GetInstance().era;

        babySprite = babyTree.GetComponent<SpriteRenderer>().sprite;
        grownupSprite = grownupTree.GetComponent<SpriteRenderer>().sprite;

        if (treeState == TreeState.Baby) {
            grownupTree.SetActive(false);
        }
        else {
            babyTree.SetActive(false);
        }

        _shadowTree = new GameObject(name + "_shadow");
        var position = transform.position;
        _shadowTree.transform.position =
            treeState == TreeState.Grownup
                ? position + _offset + babyTree.transform.localPosition
                : position + _offset + grownupTree.transform.localPosition;
        var sr = _shadowTree.AddComponent<SpriteRenderer>();
        if (treeState == TreeState.Grownup && _era == Era.Present) {
            sr.sprite = babySprite;
        }
        else if (treeState == TreeState.Baby && _era == Era.Past) {
            sr.sprite = grownupSprite;
        }
    }

    public void UpdateEra(Era era) {
        if (!gameObject.activeSelf) return;

        if (era > _era) {
            switch (treeState) {
                case TreeState.Grownup:
                    break;
                case TreeState.None:
                    babyTree.SetActive(true);
                    _shadowTree.GetComponent<SpriteRenderer>().sprite = null;
                    treeState = TreeState.Baby;
                    break;
                case TreeState.Baby:
                    babyTree.SetActive(false);
                    grownupTree.SetActive(true);
                    _shadowTree.GetComponent<SpriteRenderer>().sprite = babySprite;
                    _shadowTree.transform.position = transform.position + _offset;
                    treeState = TreeState.Grownup;
                    break;
            }
        }

        if (era < _era) {
            switch (treeState) {
                case TreeState.None:
                    break;
                case TreeState.Baby:
                    babyTree.SetActive(false);
                    _shadowTree.GetComponent<SpriteRenderer>().sprite = null;
                    treeState = TreeState.None;
                    break;
                case TreeState.Grownup:
                    babyTree.SetActive(true);
                    grownupTree.SetActive(false);
                    _shadowTree.GetComponent<SpriteRenderer>().sprite = grownupSprite;
                    _shadowTree.transform.position = transform.position + _offset;
                    treeState = TreeState.Baby;
                    break;
            }
        }

        _era = era;
    }

    public void Deactivate() {
        gameObject.SetActive(false);
        _shadowTree.SetActive(false);
    }

    private void OnEnable() {
        if (_shadowTree) {
            _shadowTree.SetActive(true);
            _shadowTree.transform.position = transform.position + _offset;
        }
        _era = TimeManager.GetInstance().era;
    }
}