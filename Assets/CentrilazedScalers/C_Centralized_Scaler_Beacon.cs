using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Centralized_Scaler_Beacon : MonoBehaviour
{
    /// <value>
    /// Current controll manager for this component
    /// </value>
    public M_Centralized_Scaler controller;
    /// <value>
    /// Target height of component owner element. Used in GetNewDimention method.
    /// </value>
    public float baseHeight = 720;
    /// <value>
    /// Target width of component owner element. Used in GetNewDimention method.
    /// </value>
    public float baseWidth = 1280;
    /// <summary>
    /// Direct resize based on current owner size
    /// </summary>
    /// <returns> None </returns>
    public void ResizeByOwner(RectTransform owner)
    {
        var uv = GetComponent<RectTransform>();
        float s = GetNewDimention(owner.rect.width, owner.rect.height);
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
