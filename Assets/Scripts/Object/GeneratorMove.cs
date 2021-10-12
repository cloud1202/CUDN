using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector3 finalPos = transform.position;
        bool isMove = false;
        int roadHeight = 0;
        while (true)
        {
            if (isMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, finalPos, 10.0f * Time.deltaTime);
                if (transform.position == finalPos) isMove = false;
            }
            else
            {
                roadHeight = Random.Range(0, 3);
                finalPos = new Vector3(transform.position.x, -3.0f + roadHeight * -2.5f, transform.position.z);
                isMove = true;
                if (transform.position == finalPos) yield return new WaitForSeconds(0.3f);
            }
            
            yield return null;
        }
    }
}
