using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ObservableCreate : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        // Observable.Create
        var observable = Observable.Create<char>(observer =>
        {
            var disposable = new CancellationDisposable();

            Task.Run(async () =>
            {
                for (var i = 0; i < 5; i++)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), disposable.Token);

                    observer.OnNext((char)('A' + i));
                }

                observer.OnCompleted();
            }, disposable.Token);

            return disposable;
        });
        
        observable.Subscribe(x => Debug.Log($"OnNext: {x}"), ex => Debug.LogError($"OnError: {ex.Message}"),
            () => Debug.Log("OnCompleted")).AddTo(this);
        
        
        
        // Normal subject subscribe
        var subject = new Subject<char>();
        
        subject.Subscribe(x => Debug.Log($"OnNext2: {x}"), ex => Debug.LogError($"OnError: {ex.Message}"),
            () => Debug.Log("OnCompleted2")).AddTo(this);
        
        for (var i = 0; i < 5; i++)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));

            subject.OnNext((char)('A' + i));
        }
        
        subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
