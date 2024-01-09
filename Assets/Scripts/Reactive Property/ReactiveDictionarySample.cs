using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactiveDictionarySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rd = new ReactiveDictionary<string, string>();
        rd.ObserveAdd().Subscribe(a => Debug.Log($"Added Value [{a.Value}] to Key [{a.Key}]"));

        rd.ObserveRemove().Subscribe(r => Debug.Log($"The value [{r.Value}] was removed from Key [{r.Key}]"));

        rd.ObserveReplace().Subscribe(r =>
            Debug.Log($"The Value [{r.OldValue}] of Key [{r.Key}] was updated to [{r.NewValue}]"));

        rd.ObserveCountChanged().Subscribe(c => Debug.Log("Count changed to: " + c));

        rd["Apple"] = "Apple";
        rd["Banana"] = "Banana";
        rd["Lemon"] = "Lemon";

        rd["Apple"] = "ApplePen";

        rd.Remove("Banana");
        
        rd.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
