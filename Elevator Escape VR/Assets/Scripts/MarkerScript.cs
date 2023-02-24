using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{

    private bool isGrabbed = false;
    private Transform CapTransform;

    //Variables for the tip to allow smooth use of drawing stuff.
    private Transform TipTransform;
    [SerializeField] private int penSize = 3;
    [SerializeField] private Color penColor;
    private Color[] penColors;

    RaycastHit result;
    private WhiteboardScript whiteboard;
    private Vector2 lastUV = new Vector2(-1.0f, -1.0f);

    public void Start()
    {
        CapTransform = transform.FindChildRecursive("Cap");
        TipTransform = transform.FindChildRecursive("Tip");

        penColors = new Color[penSize * penSize];
        for (int i = 0; i < penColors.Length; i++)
            penColors[i] = penColor;

    }

    public void onPickup()
    {

        CapTransform.localPosition = new Vector3(0.0f, 1.725f, 0.0f);
        isGrabbed = true;

    }

    public void onRelease()
    {

        CapTransform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        isGrabbed = false;

    }

    private void Update()
    {

        if (isGrabbed)
        {
            if (Physics.Raycast(TipTransform.position, -TipTransform.up, out result, 0.06f))
            {

                if (result.transform.CompareTag("Whiteboard"))
                {

                    if (whiteboard == null)
                        whiteboard = result.transform.GetComponent<WhiteboardScript>();

                    if (whiteboard != null)
                    {
                        Vector2 UV = new Vector2(result.textureCoord.x, result.textureCoord.y);
                        int x = (int)(UV.x * whiteboard.whiteboardRes.x - (penSize / 2));
                        int y = (int)(UV.y * whiteboard.whiteboardRes.y - (penSize / 2));

                        if (x >= 0 && x < whiteboard.whiteboardRes.x && y >= 0 && y < whiteboard.whiteboardRes.y)
                        {
                            if (lastUV.x >= 0.0f && lastUV.y >= 0.0f)
                            {
                                for (float f = 0.0f; f <= 1.0f; f += 0.01f)
                                    whiteboard.whiteboardTex.SetPixels((int)Mathf.Lerp(lastUV.x, x, f), (int)Mathf.Lerp(lastUV.y, y, f), penSize, penSize, penColors);
                                whiteboard.whiteboardTex.Apply();
                            }
                        }

                        lastUV = new Vector2(x, y);

                    }

                }

            }
            else
            {
                whiteboard = null;
                lastUV = new Vector2(-1.0f, -1.0f);
            }
        }

    }

}
