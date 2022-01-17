using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMove : HorizontalMove
{
    public Vector3 playerPos = new Vector3();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPos = new Vector3();
            BombGenerator.objectDestroy(this);
            if (Player.isDefence) { return; }
            GameManager.Instance.GameEnd();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "Absorption")
        {
            playerPos = other.transform.parent.position;
        }
    }
    private void Update()
    {
        base.ObjectMove(playerPos);
        if (transform.position.x <= base.destroyPosX)
        {
            playerPos = new Vector3();
            BombGenerator.objectDestroy(this);
        }
    }
}
