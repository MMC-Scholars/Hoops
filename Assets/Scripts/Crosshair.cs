using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject m_crosshair = new GameObject("Crosshair", typeof(Text));
        m_crosshair.transform.SetParent(this.transform);
        m_crosshair.GetComponent<RectTransform>().anchorMin         = new Vector2(0.5f, 0.5f);
        m_crosshair.GetComponent<RectTransform>().anchorMax         = new Vector2(0.5f, 0.5f);
        m_crosshair.GetComponent<RectTransform>().anchoredPosition  = Vector2.zero;
        m_crosshair.GetComponent<Text>().fontSize                   = 48;
        m_crosshair.GetComponent<Text>().font                       = Resources.GetBuiltinResource<Font>("Arial.ttf");
        m_crosshair.GetComponent<Text>().color                      = Color.black;
        m_crosshair.GetComponent<Text>().alignment                  = TextAnchor.MiddleCenter;
        m_crosshair.GetComponent<Text>().text                       = "+";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
