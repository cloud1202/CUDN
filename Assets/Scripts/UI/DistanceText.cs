using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    [HideInInspector]
    private TextMeshProUGUI distanceTxt;
    public float distance = 0;
    private void Awake()
    {
        distanceTxt = GetComponent<TextMeshProUGUI>();
    }
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
