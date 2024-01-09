using System.Collections;
using System.Collections.Generic;
using System.IO;
using UniRx;
using UnityEngine;

public class ObservableStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Start(() =>
        {
            using (var r = new StreamReader(@"data.txt"))
            {
                return r.ReadToEnd();
            }
        }, Scheduler.ThreadPool).Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
