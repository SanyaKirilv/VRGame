using System;
using JetBrains.Annotations;
using UnityEngine;

namespace ElectricNetwork
{
    public class Switcher : MonoBehaviour
    {
        public Transform spawnable;
        public Transform spawFolder;

        private bool _isSwitchedOn;

        private bool _status;
        
        [SerializeField] [CanBeNull] private Lamp _output;
    
        private void SendSignal(Signal signal)
        {
            if (_output is not null)
            {
                _output.TakeSignal(signal);
            }
        }

        public void TakeSignal(Signal signal)
        {
            SendSignal(signal);
        }

        public void TakePreviousStatus(bool closed)
        {
            SendStatus(_isSwitchedOn && closed);
        }

        public void SendStatus(bool status)
        {
            _status = status;
            if (_output is not null)
            {
                _output.TakePreviousStatus(status);
            }
        }

        private void Update() 
        {
            if((OVRInput.GetUp(OVRInput.RawButton.X) || Input.GetKeyDown(KeyCode.LeftShift)) && _isSwitchedOn == false)
            {
                _isSwitchedOn = true;
                Instantiate(spawnable, spawFolder.position, Quaternion.identity, spawFolder);
            }
            if((OVRInput.GetUp(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.RightShift)) && _isSwitchedOn == true)
            {
                _isSwitchedOn = false;
            }
        }
    }
}