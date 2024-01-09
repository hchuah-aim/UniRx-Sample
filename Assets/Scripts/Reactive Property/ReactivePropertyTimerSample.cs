using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertyTimerSample : MonoBehaviour
{
    [SerializeField] private IntReactiveProperty current = new IntReactiveProperty(60);

    public IReadOnlyReactiveProperty<int> CurrentTIme => current;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownCoroutine());
        current.AddTo(this);
    }

    private IEnumerator CountDownCoroutine()
    {
        while (current.Value > 0)
        {
            current.Value--;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
