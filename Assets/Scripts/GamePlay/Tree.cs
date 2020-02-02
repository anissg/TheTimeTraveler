using System;
using UnityEngine;

public enum TreeState {
    Baby,
    Grownup
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
            (treeState == TreeState.Grownup) ? position + _offset + babyTree.transform.localPosition : position + _offset + grownupTree.transform.localPosition;

        var sr = _shadowTree.AddComponent<SpriteRenderer>();
        if (treeState == TreeState.Grownup && _era == Era.Present) {
            sr.sprite = babySprite;
        }
        else if (treeState == TreeState.Baby && _era == Era.Past) {
            sr.sprite = grownupSprite;
        }
    }

    public void UpdateEra(Era era) {
        if (era > _era && treeState == TreeState.Baby) {
            grownupTree.SetActive(true);
            babyTree.SetActive(false);
            _shadowTree.GetComponent<SpriteRenderer>().sprite = babySprite;
            _shadowTree.transform.position = transform.position + _offset; // + babyTree.transform.localPosition;
            treeState = TreeState.Grownup;
        }

        else if (era < _era && treeState == TreeState.Grownup) {
            babyTree.SetActive(true);
            grownupTree.SetActive(false);
            _shadowTree.GetComponent<SpriteRenderer>().sprite = grownupSprite;
            _shadowTree.transform.position = transform.position + _offset; //+ grownupTree.transform.localPosition;
            treeState = TreeState.Baby;
        }

        _era = era;
    }

    public void Deactivate() {
        gameObject.SetActive(false);
        _shadowTree.SetActive(false);
    }

    public void OnEnable() {
        if (_shadowTree) {
            _shadowTree.SetActive(true);
            _shadowTree.transform.position = transform.position + _offset;
        }
    }
}