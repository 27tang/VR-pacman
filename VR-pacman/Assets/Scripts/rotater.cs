﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour {

    // Use this for initialization

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
