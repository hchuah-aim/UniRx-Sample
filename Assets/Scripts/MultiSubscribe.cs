using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MultiSubscribe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        var observable = subject.Do(x => Debug.Log(("Do: " + x))).Do(x => Debug.Log(("Do2: " + x)));
        observable.Subscribe(x => Debug.Log("First subscribe: " + x));
        observable.Subscribe(x => Debug.Log("Second subscribe: " + x));
        
        subject.OnNext(1);
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
