using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{

    public Vector3 playerPos = new Vector3();

    // Update is called once per frame
    void Update()
    {
        playerPos = transform.parent.position;
    }

}
