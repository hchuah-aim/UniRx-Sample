using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Do : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)).Do(x => Debug.Log(x)).Take(10).Subscribe(_ =>
        {
            
        },() => Debug.Log("10 sec"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
