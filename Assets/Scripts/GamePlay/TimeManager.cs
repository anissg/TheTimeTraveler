﻿using UnityEngine;

public enum Era {
    Past = 0,
    Present = 1
}

public class TimeManager : MonoBehaviour {
    [SerializeField] private Era era;
    [SerializeField] private Transform levelGrid;
    [SerializeField] private Transform shadowGrid;

    private static TimeManager _instance;

    public static TimeManager GetInstance() {
        return _instance;
    }

    public Vector3 Offset { get; private set; }

    void Awake() {
        _instance = this;

        Offset = shadowGrid.position - levelGrid.position;
    }

    public void SwitchEra() {
        era = era == Era.Past ? Era.Present : Era.Past;

        Debug.Log(era);
        
        var pe = transform.Find("PuzzleElements");
        foreach (Transform t in pe) {
            t.GetComponent<IPuzzleElement>()?.UpdateEra(era);
        }
    }
}