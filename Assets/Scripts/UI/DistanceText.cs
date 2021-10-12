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
        distanceTxt = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void DistanceUpdate()
    {
        distance += Time.deltaTime;
        // 소수점 둘째 자리까지 반올림
        distance = Mathf.Round(distance * 100) * 0.01f;
        distanceTxt.text = distance + "";
    }

    public void InitDistance()
    {
        distance = 0;
        distanceTxt.text = "0.0";
    }
}
