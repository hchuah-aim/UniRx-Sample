using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Merge3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IEnumerable<IObservable<int>> streams = new[]
        {
            Observable.Range(100, 3),
            Observable.Range(200, 3),
            Observable.Range(300, 3),
        };

        streams.Merge().Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
