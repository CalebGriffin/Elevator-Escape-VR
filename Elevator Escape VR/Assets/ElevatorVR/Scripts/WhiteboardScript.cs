using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardScript : MonoBehaviour
{

    //This is to generate a whiteboard texture.
    public Vector2 whiteboardRes;
    public Texture2D whiteboardTex;

    //Applying the whiteboard texture.
    private void Awake()
    {
        Renderer render = GetComponent<Renderer>();
        whiteboardTex = new Texture2D((int)whiteboardRes.x, (int)whiteboardRes.y, TextureFormat.RGBA32, false);

        Color[] pixels = new Color[(int)whiteboardRes.x * (int)whiteboardRes.y];
        for (int i = ((int)whiteboardRes.x * (int)whiteboardRes.y) - 1; i > -1; i--)
            pixels[i].r = pixels[i].g = pixels[i].b = (137.0f / 255.0f);

        whiteboardTex.SetPixels(0, 0, (int)whiteboardRes.x, (int)whiteboardRes.y, pixels);
        whiteboardTex.Apply();

        render.material.mainTexture = whiteboardTex;
    }

    public void clearWhiteboard()
    {
        if (whiteboardTex != null)
        {
            whiteboardTex.Reinitialize((int)whiteboardRes.x, (int)whiteboardRes.y, TextureFormat.RGBA32, false);

            Color[] pixels = new Color[(int)whiteboardRes.x * (int)whiteboardRes.y];
            for (int i = ((int)whiteboardRes.x * (int)whiteboardRes.y) - 1; i > -1; i--)
                pixels[i].r = pixels[i].g = pixels[i].b = (137.0f / 255.0f);

            whiteboardTex.SetPixels(0, 0, (int)whiteboardRes.x, (int)whiteboardRes.y, pixels);
            whiteboardTex.Apply();
        }
    }
}
