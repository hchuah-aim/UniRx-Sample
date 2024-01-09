using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RxOperationHotObservable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var originalSubject = new Subject<string>();

        IConnectableObservable<string> appendStringObservable =
            originalSubject.Scan((previous, current) => previous + " " + current).Last().Publish();
        var disposable = appendStringObservable.Connect();
        
        originalSubject.OnNext("I");
        originalSubject.OnNext("have");

        appendStringObservable.Subscribe(x => Debug.Log(x));
        
        originalSubject.OnNext("a");
        originalSubject.OnNext("pen");
        originalSubject.OnCompleted();
        
        disposable.Dispose();
        originalSubject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
