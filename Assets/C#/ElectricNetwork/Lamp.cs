using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace ElectricNetwork
{
    public class Lamp : MonoBehaviour, IResistor
    {
        [SerializeField]
        private decimal resistance = 1;
        
        private decimal _voltage;
        private decimal _amperage;
        private bool _isLampOn = false;

        public decimal Resistance => resistance;
        public decimal Voltage => _voltage;
        private decimal Amperage => _amperage;

        private Signal _signal;
        [SerializeField] [CanBeNull] private Resistor _output;

        private bool _status;

        private void SendSignal(Signal signal)
        {
            if (_output is not null)
            {
                _output.TakeSignal(signal);
            }
        }

        public void TakeSignal(Signal signal)
        {
            _isLampOn = signal.EMF != decimal.Zero;
            _signal = signal;
            React();
            SendSignal(signal);
        }

        public void TakePreviousStatus(bool closed)
        {
            _status = closed;
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
    
        private void Update()
        {
            if (_isLampOn)
            {
                this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            }
            else
            {
                this.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
        }
    }
}