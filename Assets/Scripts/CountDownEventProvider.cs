using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CountDownEventProvider : MonoBehaviour
{
    [SerializeField] private int _countSeconds = 10;

    private Subject<int> _subject;

    public IObservable<int> CountDownObservable => _subject;

    private void Awake()
    {
        _subject = new Subject<int>();
        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        var current = _countSeconds;
        
        while (current > 0)
        {
            _subject.OnNext((current));
            current--;
            yield return new WaitForSeconds(1.0f);
        }
        
        _subject.OnNext(0);
        _subject.OnCompleted();
    }

    private void OnDestroy()
    {
        _subject.Dispose();
    }
}
