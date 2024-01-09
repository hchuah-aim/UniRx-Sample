using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Where : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(0, 100).Where((x, y) => x % 2 == 0 && y < 5).Subscribe(x => Debug.Log(x));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
