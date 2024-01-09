using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Zip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var array = new[] { "A", "B", "C", "D" };
        var stream1 = Observable.Range(0, 3);
        array.ToObservable().Zip(stream1, (s, i) => $"{s} : {i}").Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
