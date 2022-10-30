using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [Serialize]
    private bool _isPicked;
    void Start()
    {
        _isPicked = true;
    }

    void FixedUpdate()
    {
        
    }

    private void OnMouseDown()
    {
        if (_isPicked)
        {
            this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            this.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
        _isPicked = !_isPicked;
    }
}
