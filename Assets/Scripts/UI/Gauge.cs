using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    // 먹어야 하는 아이템 갯수
    public static float eatItem= 5.0f;
    public static bool GaugeFill(Image boosterGauge)
    {
        boosterGauge.fillAmount += 1.0f / eatItem;
        if (boosterGauge.fillAmount == 1) return true;
        return false;
    }
    public static IEnumerator GaugeEmpty(Image boosterGauge)
    {
        float boostTime = 0.0f;
        while (boostTime < 10.0f)
        {
            boosterGauge.fillAmount -= 0.1f * Time.deltaTime;
            boostTime += Time.deltaTime;
            yield return null;
        }
        Player.playerRb.useGravity = true;
        Player.isBoost = false;
        Player.isBoosterGauge = false;
        Time.timeScale = 1;
        yield return null;
    }
}
