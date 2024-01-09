using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class SelectMany2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.ObserveEveryValueChanged(x => x.position).Throttle(TimeSpan.FromSeconds(1))
            .Select(_ => 10)
            .SelectMany(x => Observable.Range(x * 10, 3), (input, output) => (input, output))
            .Subscribe(x => Debug.Log($"{x.input} : {x.output}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
