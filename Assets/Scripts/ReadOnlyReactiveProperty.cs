using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReadOnlyReactiveProperty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var intReactiveProperty = new ReactiveProperty<int>(100);

        var readOnlyInt = intReactiveProperty.ToReadOnlyReactiveProperty();
        
        Debug.Log("ReadOnly Value: " + readOnlyInt.Value);
        readOnlyInt.Subscribe(x => Debug.Log("Notified Value: " + readOnlyInt.Value));

        //readOnlyInt.Value = 10; no write
        
        intReactiveProperty.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
