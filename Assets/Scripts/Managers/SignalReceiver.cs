using UnityEngine;
using UnityEngine.Events;

public class SignalReceiver : MonoBehaviour
{
    public Signal signal;
    public UnityEvent unityEvent;

    void Start()
    {
        signal.SignIn(this);
    }

    void OnDisable()
    {
        signal.SignOut(this);
    }
}
