using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TakeLast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var array = new[] { 1, 3, 4, 7, 2, 5, 9 };

        array.ToObservable().TakeLast(3).Subscribe(x => Debug.Log(x), () => Debug.Log("OnCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
