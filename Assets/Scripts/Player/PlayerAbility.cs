using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private void Start()
    {
        UiManager.Instance.AddListnerEvent(UiManager.Buttons.Eatter, () => ClickAbility(UiManager.Buttons.Eatter));
        UiManager.Instance.AddListnerEvent(UiManager.Buttons.Defender, () => ClickAbility(UiManager.Buttons.Defender));
        UiManager.Instance.AddListnerEvent(UiManager.Buttons.Jumper, () => ClickAbility(UiManager.Buttons.Jumper));
        UiManager.Instance.AddListnerEvent(UiManager.Buttons.Booster, () => ClickAbility(UiManager.Buttons.Booster));
    }
    public void ClickAbility(UiManager.Buttons ability)
    {
        if (Player.ability == ability || Player.IsBoost || (ability.Equals(UiManager.Buttons.Booster) && !Gauge.IsBoosterGauge)) { return; }
        
        if (ability.Equals(UiManager.Buttons.Booster) && Gauge.IsBoosterGauge) { StartCoroutine(Gauge.GaugeEmpty()); }
        
        Player.ability = ability;
        float coolDownTime = 1.0f;
        AbilityCoolDown.instance.CoolDownEnable(ability, coolDownTime);
    }
}
