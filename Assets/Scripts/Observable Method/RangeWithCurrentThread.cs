using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RangeWithCurrentThread : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(start: 0, count: 5, scheduler: Scheduler.CurrentThread)
            .Subscribe(x => Debug.Log($"frame: {Time.frameCount} value: {x}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
