using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class UnityTool
{
    private static UnityTool instance;
    public static UnityTool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UnityTool();
            }
            return instance;
        }
    }
    private GameObject m_Canvas;
    private UnityTool()
    {
        m_Canvas = GameObject.Find("Canvas");
    }

    public GameObject GetGameObjectFromCanvas(string name)
    {
        foreach (Transform obj in m_Canvas.GetComponentsInChildren<Transform>(true))
        {
            if (obj.name == name)
            {
                return obj.gameObject;
            }
        }
        Debug.Log("UnityTool GetGameObjectFromCanvas(" + name + ") return null");
        return null;
    }
}
