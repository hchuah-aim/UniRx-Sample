using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ObservableInterval : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Observable.Interval
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe().AddTo(this);

        // Observable.Timer
        Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1)).Subscribe().AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
