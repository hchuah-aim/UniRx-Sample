using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SubscribeTiming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<string>();

        var appendingStringObservable = subject.Scan((previous, current) => previous + " " + current).Last();
        
        subject.OnNext("I");
        subject.OnNext("have");
        
        appendingStringObservable.Subscribe(x => Debug.Log(x));
        
        subject.OnNext("a");
        subject.OnNext("pen");
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
