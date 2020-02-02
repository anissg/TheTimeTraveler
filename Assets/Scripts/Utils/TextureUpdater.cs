using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class TextureUpdater : MonoBehaviour
{
    public RenderTexture renderTexture;
    private SpriteRenderer spriteRenderer;
    private Texture2D texture2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        texture2D = new Texture2D(renderTexture.width, renderTexture.height);
    }

    // Update is called once per frame
    void Update()
    {
        
        texture2D.LoadRawTextureData(renderTexture.GetNativeTexturePtr(), renderTexture.height * renderTexture.width);
        texture2D.Apply();

        spriteRenderer.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 1.0f);
    }
}
