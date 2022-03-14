using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour, IMove
{
    private const float moveSpeed = 10.0f;
    protected float destroyPosX = -45.0f;

    public void ObjectMove(Vector3 finalPos = new Vector3())
    {
        if (finalPos == new Vector3())
        {
            finalPos = new Vector3(destroyPosX, transform.position.y, transform.position.z);
        }
        gameObject.transform.position = Vector3.MoveTowards(transform.position, finalPos, moveSpeed * Time.deltaTime);
    }
}
