using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

public class Week11_GameManager : MonoBehaviour
{

    [SerializeField] private float _force;
    public static UnityEvent OnRunEvent = new();
    public static UnityEvent OnStopEvent = new();
    public static UnityEvent<float> OnSetForceEvent = new();

    private void Update()
    {
        OnSetForceEvent.Invoke(_force);
    }

    [Button]
    public void Run()
    {
        OnRunEvent.Invoke();
    }

    [Button]
    public void Stop()
    {
        OnStopEvent.Invoke();
    }

}