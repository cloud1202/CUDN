using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : HorizontalMove
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CoinGenerator.objectDestroy(this);
            UiManager.Instance.ScoreUpdate();
        }
    }
    private void Update()
    {
        base.ObjectMove();
        if (transform.position.x <= base.destroyPos) CoinGenerator.objectDestroy(this);
    }
}
