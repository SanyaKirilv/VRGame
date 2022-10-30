using JetBrains.Annotations;
using UnityEngine;
using ElectricNetwork;
public class CurrentSoruce : MonoBehaviour
{
    [SerializeField] [CanBeNull] private Switcher _output;

    [SerializeField]
    private decimal _EMF = 100;
    
    [SerializeField]
    private decimal _innerResistance = 5;
    
    private bool _status;

    private Signal _signal;
    private Signal GenerateSignal(decimal EMF, decimal innerResistance)
    {
        return new Signal(EMF, innerResistance);
    }

    private void SendSignal(Signal signal)
    {
        if (_output is not null)
        {
            _output.TakeSignal(signal);
        }
    }

    public void TakeSignal(Signal signal)
    {
        if (signal.EMF != 0)
        {
            _signal = signal;
            _signal.Calculate();
        }
    }

    public void TakePreviousStatus(bool closed)
    {
        if (_status == closed) return;
        _signal = GenerateSignal(_EMF, _innerResistance);
        _status = closed;
    }

    private void SendStatus(bool status)
    {
        if (_output is not null)
        {
            _output.TakePreviousStatus(status);
        }
    }
    
    void Start()
    {
        _signal = GenerateSignal(_EMF, _innerResistance);
    }

    void FixedUpdate()
    {
        SendStatus(true);
        if (_status)
        {
            SendSignal(_signal);
        }
        else
        {
            SendSignal(Signal.Interupted);
        }
    }

    public Signal Signal => _signal;
}
