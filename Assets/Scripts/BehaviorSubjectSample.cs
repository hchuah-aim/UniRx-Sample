using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class BehaviorSubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var behaviorSubject = new BehaviorSubject<int>(0);
        behaviorSubject.OnNext(1);
        behaviorSubject.OnNext(10);
        
        behaviorSubject.Subscribe(x => Debug.Log("OnNext: " + x), ex => Debug.LogError("OnError: " + ex),
            () => Debug.Log("OnCOmpleted"));
        
        behaviorSubject.OnNext(2);
        
        Debug.Log("Last Value: " + behaviorSubject.Value);
        
        behaviorSubject.OnNext(3);
        behaviorSubject.OnCompleted();
        behaviorSubject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
