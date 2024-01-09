using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var mouseDown = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
        mouseDown.Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(500))).Where(x => x.Count == 2)
            .Subscribe(_ => Debug.Log("Double"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
