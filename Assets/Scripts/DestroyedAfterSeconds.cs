﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedAfterSeconds : MonoBehaviour
{
    public float seconds = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;

        if (seconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
