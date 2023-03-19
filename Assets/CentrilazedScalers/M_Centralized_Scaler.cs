using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Centralized_Scaler : MonoBehaviour
{
    /// <value>
    /// Controlled instances of <see cref="C_Centralized_Scaler_Beacon"/>
    /// </value>
    public List<C_Centralized_Scaler_Beacon> subcontrolled = new List<C_Centralized_Scaler_Beacon>();
    /// <value>
    /// Parent of controlled instances of <see cref="C_Centralized_Scaler_Beacon"/>
    /// </value>
    public RectTransform container;
    /// <value>
    /// Parent of controlled instances of <see cref="C_Centralized_Scaler_Beacon"/>
    /// </value>
    public bool collectOnEnable = false;
    public void OnEnable()
    {
        if (collectOnEnable) CollectSubcontrolled();
    }
    /// <summary>
    /// Collecting new instances of <see cref="C_Centralized_Scaler_Beacon"/> which dont have another controller
    /// </summary>
    public void CollectSubcontrolled()
    {
        if (container != null)
        {
            foreach(Transform s in container.transform)
            {
                C_Centralized_Scaler_Beacon comp;
                if (s.TryGetComponent(out comp))
                {
                    if (!subcontrolled.Contains(comp))
                    {
                        if (comp.controller == null)
                        {
                            comp.controller = this;
                            subcontrolled.Add(comp);
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// Unbinding instances of <see cref="C_Centralized_Scaler_Beacon"/> which controlled by this manager
    /// </summary>
    public void ClearSubcontrolled()
    {
        foreach(var s in subcontrolled)
        {
            s.controller = null;
        }
        subcontrolled.Clear();
    }
    /// <summary>
    /// Resizes instances of <see cref="C_Centralized_Scaler_Beacon"/> which controlled by this manager based on given resize multiplier
    /// <param name="dim">Resize multiplier</param>
    /// </summary>
    public void ResizeSubcontrolled(float dim)
    {
        foreach(var s in subcontrolled)
        {
            RectTransform uv;
            if (s.TryGetComponent(out uv))
            {
                if (dim >= 0)
                {
                    uv.sizeDelta = new Vector2(uv.rect.width * dim, uv.rect.height * dim);
                }
            }
        }
    }
    /// <summary>
    /// Resizes instances of <see cref="C_Centralized_Scaler_Beacon"/> which controlled by this manager based on dimention, setted in every instance
    /// </summary>
    public void ResizeSubcontrolled()
    {
        foreach (var s in subcontrolled)
        {
            s.ResizeByOwner(container);
        }
    }
}
