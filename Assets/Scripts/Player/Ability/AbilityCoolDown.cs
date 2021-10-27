using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCoolDown : MonoBehaviour
{
    public static AbilityCoolDown instance;

    [HideInInspector]
    //public float coolDownTime = 1.0f;

    private void Awake()
    {
        instance = this;
    }

    public void CoolDownEnable(GameObject ability, float coolDownTime)
    {
        UiManager.Instance.CoolDownActivation(ability);
        StartCoroutine(CoolDownTime(ability, coolDownTime));
    }
    public void CoolDownDisable(GameObject ability, float coolDownTime)
    {
        StopCoroutine(CoolDownTime(ability, coolDownTime));
    }
    public IEnumerator CoolDownTime(GameObject ability, float coolDownTime)
    {
        while (coolDownTime > 0.0f)
        {
            coolDownTime -= Time.deltaTime;
            UiManager.Instance.CoolDownTimeUpdate(ability, coolDownTime);
            yield return null;
        }
        UiManager.Instance.CoolDownDisable(ability);
        CoolDownDisable(ability, coolDownTime);
    }
}
