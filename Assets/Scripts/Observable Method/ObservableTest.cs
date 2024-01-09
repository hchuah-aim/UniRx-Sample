using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class ObservableTest : MonoBehaviour
{
    [SerializeField] private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button.OnClickAsObservable()
            .SelectMany(Test())
            .SelectMany(DeferTest())
            .Subscribe(x => Debug.Log(x));
        
    }

    private IObservable<DateTime> Test()
    {
        Debug.Log("b");
        return Observable.Return(System.DateTime.Now);
    }
    
    private IObservable<DateTime> DeferTest()
    {
        return Observable.Defer(() =>
        {
            Debug.Log("a");
            return Observable.Return(System.DateTime.Now);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
