using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    float defaultPosY;
    public static Vector3 changePos;
    bool isChange;
    int randHeight = 0;
    void Start()
    {
        changePos = transform.position;
        defaultPosY = transform.position.y;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            randHeight = Random.Range(0, 3);
            changePos = new Vector3(transform.position.x, defaultPosY + randHeight * 4.0f, transform.position.z);
            if (transform.position == changePos) isChange = false;
            else isChange = true;

            if (transform.position.y < changePos.y) yield return new WaitForSeconds(1.2f);
            else if (transform.position.y >= changePos.y) yield return null;
            transform.position = changePos;
        }
    }
}
