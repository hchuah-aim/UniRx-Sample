using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AddToSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.IntervalFrame(5).Subscribe(_ => Debug.Log("Do!")).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
