using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Merge2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IObservable<IObservable<int>> streams = Observable.Range(1, 3, Scheduler.Immediate).Select(x =>
        {
            Debug.Log("Outer");
            return Observable.Range(x * 100, 3, Scheduler.Immediate);
        });

        streams.Merge().Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
