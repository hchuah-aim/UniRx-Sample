using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OperatorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        subject.Subscribe(x => Debug.Log("raw: " + x), () => Debug.Log("OnCompleted"));
        //subject.Where(x => x > 0).Subscribe(x => Debug.Log("filter: " + x));
        
        subject.OnNext(1);
        subject.OnNext(-1);
        subject.OnNext(3);
        subject.OnNext(0);
        
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
