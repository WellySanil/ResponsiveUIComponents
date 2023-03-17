using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Individual_Scaler : MonoBehaviour
{
    public Canvas canvas;
    public void OnEnable()
    {
        OnCanvasResize(0f);
    }
    public void OnCanvasResize(float data)
    {
        var uv = GetComponent<RectTransform>();
        float s = GetNewDimention(uv.rect.width, uv.rect.height, Screen.width, Screen.height);
        uv.sizeDelta = new Vector2(uv.rect.width * s, uv.rect.height * s);
    }
    public float GetNewDimention(float width, float height, float screenWidth, float screenHeight)
    {
        float oldDim = width / height;
        float baseHeight = 720;
        float baseWidth = 1280;
        float tempRes = 1;
        if (width > height)
        {
            tempRes = screenWidth / baseWidth;
            while (height * tempRes > screenHeight)
            {
                tempRes -= 0.01f;
            }
            return tempRes;
        }
        else
        {
            tempRes = screenHeight / baseHeight;
            while (width * tempRes > screenWidth)
            {
                tempRes -= 0.01f;
            }
            return tempRes;
        }

    }
}
