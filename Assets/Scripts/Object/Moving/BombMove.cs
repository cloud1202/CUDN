using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMove : HorizontalMove
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.GameEnd();
        }
    }
    private void Update()
    {
        base.ObjectMove();
        if (transform.position.x <= base.destroyPos) BombGenerator.objectDestroy(this);
    }
}
