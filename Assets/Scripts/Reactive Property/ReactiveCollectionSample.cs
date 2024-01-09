using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactiveCollectionSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rc = new ReactiveCollection<int>();

        rc.ObserveAdd().Subscribe(a =>
        {
            Debug.Log($"Add [{a.Index}:{a.Value}]");
        });

        rc.ObserveRemove().Subscribe(r => Debug.Log($"Remove [{r.Index}:{r.Value}]"));

        rc.ObserveReplace().Subscribe(r => Debug.Log($"Replace [{r.Index}:{r.OldValue}] => [{r.NewValue}]"));

        rc.ObserveCountChanged().Subscribe(c => Debug.Log("Count: " + c));

        rc.ObserveMove().Subscribe(x => Debug.Log($"Move [{x.Value}:{x.OldIndex} => {x.NewIndex}]"));
        
        rc.Add(1);
        rc.Add(2);
        rc.Add(3);
        rc[1] = 5;
        rc.RemoveAt(0);
        
        rc.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
