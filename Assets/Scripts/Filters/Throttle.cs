using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Throttle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.ObserveEveryValueChanged(x => x.position).Throttle(TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
