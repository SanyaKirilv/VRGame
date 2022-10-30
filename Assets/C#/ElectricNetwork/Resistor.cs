using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace ElectricNetwork
{
    public class Resistor : MonoBehaviour, IResistor
    {
        [SerializeField]
        private decimal resistance = 10;

        private decimal _voltage;
        private decimal _amperage;
        
        public decimal Amperage => _amperage;
        public decimal Resistance => resistance;
        public decimal Voltage => _voltage;

        private Signal _signal;
        
        [SerializeField]
        [CanBeNull] private CurrentSoruce _output;
        

        private void SendSignal(Signal signal)
        {
            if (_output is not null)
            {
                _output.TakeSignal(signal);
            }
        }

        public void TakeSignal(Signal signal)
        {
            _signal = signal;
            React();
            SendSignal(signal);
        }

        public void TakePreviousStatus(bool closed)
        {
            SendStatus(closed);
        }

        private void SendStatus(bool status)
        {
            if (_output is not null)
            {
                _output.TakePreviousStatus(status);
            }
        }
        
        public void React()
        {
            if (!_signal.Calculated)
            {
                _signal.AddResistance(this, resistance);
            }
            else
            {
                _amperage = _signal.Amperage;
                _voltage = _signal.Amperage * resistance;
            }
        }
    }
}