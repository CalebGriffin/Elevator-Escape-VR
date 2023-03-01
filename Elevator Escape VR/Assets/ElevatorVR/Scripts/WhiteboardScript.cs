using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardScript : MonoBehaviour
{

    //This is to generate a whiteboard texture.
    public Vector2 whiteboardRes;
    public Texture2D whiteboardTex;

    //Applying the whiteboard texture.
    private void Start()
    {
        Renderer render = GetComponent<Renderer>();
        whiteboardTex = new Texture2D((int)whiteboardRes.x, (int)whiteboardRes.y, TextureFormat.RGBA32, false);
        render.material.mainTexture = whiteboardTex;
    }

}
