using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour, IMove
{
    private int moveSpeed = 10;
    Vector3 pos;
    protected float destroyPos = -45.0f;

    public void ObjectMove()
    {
        pos = new Vector3(destroyPos, transform.position.y, transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);
    }
}
