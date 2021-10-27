using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMove : HorizontalMove
{
    private void Update()
    {
        base.ObjectMove();
        if (transform.position.x <= base.destroyPosX) BoardGenerator.objectDestroy(this);
    }
}
