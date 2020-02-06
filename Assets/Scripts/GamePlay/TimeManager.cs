using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Era {
    Past = 0,
    Present = 1
}

public class TimeManager : MonoBehaviour {
    [SerializeField] public Era era;
    [SerializeField] private Transform levelGrid;
    [SerializeField] private Transform shadowGrid;
    [SerializeField] private Transform player;
    [Header("Level Set Up")]
    [SerializeField] private Transform[] MainCamPos;
    [SerializeField] private Transform[] OtherCamPos;
    [SerializeField] private Transform[] PlayerPos;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject past;
    [SerializeField] public float gridScale;

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

        present.SetActive(!present.activeSelf);
        past.SetActive(!past.activeSelf);
        
        var pe = transform.Find("PuzzleElements");

        if(pe != null)
            foreach (Transform t in pe)
                t.GetComponent<IPuzzleElement>()?.UpdateEra(era);
        //MusicManager.Instance.SwitchMusic();
    }


    public void SetLevel(int i)
    {
        StartCoroutine(SetLevelProperties(i));
    }

    IEnumerator  SetLevelProperties(int i)
    {
        UIManager.Instance.FadeIn();
        yield return new WaitForSeconds(1f);
        Camera.main.transform.position = MainCamPos[i].position;
        Camera.main.transform.position = MainCamPos[i].position;
        player.position = PlayerPos[i].position;
        UIManager.Instance.FadeOut();
    }
}