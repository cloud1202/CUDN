﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMove : Move
{
    private void Update()
    {
        base.ObjectMove();
        if (transform.position.x <= base.destroyPos) BoardGenerator.objectDestroy(this);
    }
}
