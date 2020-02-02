using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCameraScaler : MonoBehaviour
{ 
    public void Start()
    {
        float y = Camera.main.orthographicSize * 2.0f;
        float x = y * Screen.width / Screen.height;
        transform.localScale = new Vector3(x, y, 1);
    }
}
