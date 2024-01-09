using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SubjectHotObservable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var originalSubject = new Subject<string>();

        var appendingStringObservable = originalSubject.Scan((previous, current) => previous + " " + current).Last();

        var publishSubject = new Subject<string>();

        appendingStringObservable.Subscribe(publishSubject);
        
        originalSubject.OnNext("I");
        originalSubject.OnNext("have");

        publishSubject.Subscribe(x => Debug.Log(x));
        
        originalSubject.OnNext("a");
        originalSubject.OnNext("pen");
        originalSubject.OnCompleted();
        
        publishSubject.Dispose();
        originalSubject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
