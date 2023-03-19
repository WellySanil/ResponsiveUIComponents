using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Individual_Scaler : MonoBehaviour
{
    /// <value>
    /// Is component resizes on enable?
    /// </value>
    public bool isResizeOnEnable = false;
    /// <value>
    /// Target height of component owner element. Used in GetNewDimention method.
    /// </value>
    public float baseHeight = 720;
    /// <value>
    /// Target width of component owner element. Used in GetNewDimention method.
    /// </value>
    public float baseWidth = 1280;
    public void OnEnable()
    {
        if (isResizeOnEnable) Resize();
    }
    /// <summary>
    /// Direct resize based on input multiplier
    /// </summary>
    /// <param name="dim">Resize multiplier</param>
    /// <returns> Is resized </returns>
    public bool Resize(float dim)
    {
        var uv = GetComponent<RectTransform>();
        if (dim >= 0)
        {
            uv.sizeDelta = new Vector2(uv.rect.width * dim, uv.rect.height * dim);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Direct resize based on current screen dim
    /// </summary>
    /// <returns> None </returns>
    public void Resize()
    {
        var uv = GetComponent<RectTransform>();
        float s = GetNewDimention(Screen.width, Screen.height);
        uv.sizeDelta = new Vector2(uv.rect.width * s, uv.rect.height * s);
    }

    /// <summary>
    /// Direct resize based on input multiplier
    /// </summary>
    /// <param name="screenWidth"> New screen width </param>
    /// <param name="screenHeight"> New screen height </param>
    /// <returns> Calculated dimention </returns>
    public float GetNewDimention(float screenWidth, float screenHeight)
    {
        var uv = GetComponent<RectTransform>();
        float width = uv.rect.width;
        float height = uv.rect.height;
        float tempRes = 1;
        if (width > height)
        {
            tempRes = screenWidth / baseWidth;
            while (height * tempRes > screenHeight)
            {
                tempRes -= 0.01f;
            }
        }
        else
        {
            tempRes = screenHeight / baseHeight;
            while (width * tempRes > screenWidth)
            {
                tempRes -= 0.01f;
            }
        }
        return tempRes;
    }
}
