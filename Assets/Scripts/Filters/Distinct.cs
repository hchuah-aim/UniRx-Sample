using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Distinct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var array = new[] { 1, 1, 2, 2, 3, 1, 2, 2, 2, 3, 3 };
        array.ToObservable().Distinct().Subscribe(x => Debug.Log("Distinct: " + x));
        array.ToObservable().DistinctUntilChanged().Subscribe(x => Debug.Log("DistinctUntilChanged: " + x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
