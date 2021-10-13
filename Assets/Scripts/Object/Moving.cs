using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    float yt;
    public static Vector3 changePos;
    bool isChange;
    void Start()
    {
        changePos = transform.position;
        yt = transform.position.y;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        int i = 0;
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            i = Random.Range(0, 3);
            changePos = new Vector3(transform.position.x, yt + i * 4.0f, transform.position.z);
            if (transform.position == changePos) isChange = false;
            else isChange = true;

            if (transform.position.y < changePos.y) yield return new WaitForSeconds(0.9f);
            else if (transform.position.y >= changePos.y) yield return null;
            transform.position = changePos;
        }
    }
}
