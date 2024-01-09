using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactPropertyForceNotify : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var health = new ReactiveProperty<int>(100);
        health.Subscribe(x => Debug.Log("health changed: " + x));
        
        Debug.Log("Set Health to 100");
        health.Value = 100;
        
        Debug.Log("Force Notify");
        health.SetValueAndForceNotify(100);
        
        health.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
