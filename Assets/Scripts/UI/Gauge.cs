using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    // 먹어야 하는 아이템 갯수
    private static float eatItem = 5.0f;
    public static bool IsBoosterGauge { get { return gaugeImage.fillAmount == 1.0f ? true : false; } }
    private static Image gaugeImage = UiManager.Instance.GaugeImage;
    public static void GaugeFill()
    {
        gaugeImage.fillAmount += 1.0f / eatItem;
    }
    public static void GaugeReset()
    {
        gaugeImage.fillAmount = 0.0f;
    }
    public static IEnumerator GaugeEmpty()
    {
        Player.Instance.PlayerRb.useGravity = false;
        float boostTime = 0.0f;
        Time.timeScale = 2;
        while (boostTime < 10.0f)
        {
            gaugeImage.fillAmount -= 0.1f * Time.deltaTime;
            boostTime += Time.deltaTime;
            yield return null;
        }
        Player.Instance.PlayerRb.useGravity = true;
        Time.timeScale = 1;
        Player.ability = "Eatter";
        yield return null;
    }
}
