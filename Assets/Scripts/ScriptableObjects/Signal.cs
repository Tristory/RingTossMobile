using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SignalObject")]
public class Signal : ScriptableObject
{
    List<SignalReceiver> signalReceivers;

    public void Raise()
    {
        foreach (SignalReceiver receiver in signalReceivers)
        {
            receiver.unityEvent.Invoke();
        }
    }

    public void SignIn(SignalReceiver receiver)
    {
        signalReceivers.Add(receiver);
    }

    public void SignOut(SignalReceiver receiver)
    {
        signalReceivers.Remove(receiver);
    }
}
