using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public void ClickAbility(GameObject ability)
    {
        if (Player.ability == ability.name || Player.IsBoost || (ability.name == "Booster" && !Gauge.IsBoosterGauge)) { return; }
        
        if (ability.name == "Booster" && Gauge.IsBoosterGauge) { StartCoroutine(Gauge.GaugeEmpty()); }
        
        Player.ability = ability.name;
        float coolDownTime = 1.0f;
        AbilityCoolDown.instance.CoolDownEnable(ability, coolDownTime);
    }
}
