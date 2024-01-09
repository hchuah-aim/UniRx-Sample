using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MessageSample : MonoBehaviour
{
    [SerializeField] private float _countTimeSeconds = 5f;

    public IObservable<Unit> OnTimeUpAsyncSubject => _onTimeUpAsyncSubject;

    private readonly AsyncSubject<Unit> _onTimeUpAsyncSubject = new AsyncSubject<Unit>();

    private IDisposable _disposable;
    
    // Start is called before the first frame update
    void Start()
    {
        _disposable = Observable.Timer(TimeSpan.FromSeconds(_countTimeSeconds))
            .Subscribe(_ =>
            {
                _onTimeUpAsyncSubject.OnNext(Unit.Default);
                _onTimeUpAsyncSubject.OnCompleted();
            });
    }

    // Update is called once per frame
    void OnDestroy()
    {
        _disposable?.Dispose();
        _onTimeUpAsyncSubject.Dispose();
    }
}
