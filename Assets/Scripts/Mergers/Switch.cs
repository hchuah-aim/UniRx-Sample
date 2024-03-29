using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IObservable<IObservable<Vector3>> targetObservable = this.OnCollisionEnterAsObservable()
            .Select(x =>
            {
                var target = x.gameObject;
                return CreatePositionObservable(target);
            });

        targetObservable
            .Switch()
            .Subscribe(target => transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime));
    }

    // Update is called once per frame
    IObservable<Vector3> CreatePositionObservable(GameObject target)
    {
        return target.UpdateAsObservable()
            .Select(_ => target.transform.position);
    }
}
