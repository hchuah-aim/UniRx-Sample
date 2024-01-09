using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

public class ObserveOnSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var task = Task.Run(() => File.ReadAllText(@"data.txt"));
        task.ToObservable().ObserveOn(Scheduler.MainThread).Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
