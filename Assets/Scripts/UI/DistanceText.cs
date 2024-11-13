using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    private TextMeshProUGUI m_distanceTxt;
    public TextMeshProUGUI distanceTxt
    {
        get
        {
            if (m_distanceTxt == null)
                m_distanceTxt = GetComponent<TextMeshProUGUI>();

            return m_distanceTxt;
        }
    }
    public float distance = 0;

    public void DistanceUpdate()
    {
        distance += Time.deltaTime;
        // 소수점 첫째 자리만 츨력
        distanceTxt.text = $"{distance:F1}";
    }

    public void InitDistance()
    {
        distance = 0;
        distanceTxt.text = "0.0";
    }
}
