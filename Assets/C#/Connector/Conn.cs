using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Connector
{
    public class Conn : MonoBehaviour
    {
        private static Conn _instance;  
        
        private bool _inWork;

        public static Conn Instance => _instance;

        [CanBeNull] private GameObject _oneGameObject;

        [CanBeNull] private GameObject _anotherGameObject;

        private void Start()
        {
            if (_instance is null)
            {
                _instance = this;
            }
            else if (_instance == this)
            {
                Destroy(gameObject);
            }
        }

        public void SetOneGameObject(GameObject gameObject)
        {
            if (!_inWork)
            {
                _oneGameObject = gameObject;
                _inWork = true;
            }
        }

        public void SetAnotherGameObject(GameObject gameObject)
        {
            if (_inWork)
            {
                _anotherGameObject = gameObject;
                
            }
        }

        private void Update()
        {
            var color = new Color(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 255),
                UnityEngine.Random.Range(0, 100));
            if (_oneGameObject is not null)
            {
                _oneGameObject.GetComponent<Renderer>().material.color = color;
            }

            if (_anotherGameObject is not null)
            {
                _anotherGameObject.GetComponent<Renderer>().material.color = color;
            }
        }
    }
}