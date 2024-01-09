using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ThrottleFirst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.ObserveEveryValueChanged(x => x.position).ThrottleFirst(TimeSpan.FromSeconds(1)).Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
