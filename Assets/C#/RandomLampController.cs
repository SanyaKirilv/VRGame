using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLampController : MonoBehaviour
{
    public GameObject lamp;
    private float timeOff;
    private bool isOff = false;

    void Start()
    {
        LampOn();
    }

    void Update()
    {
        timeOff -= Time.deltaTime;
        if (timeOff < 0)
        {   
            if(!isOff) LampOff();
            else LampOn();
        }
    }

    private void LampOn()
    {
        lamp.SetActive(true);
        timeOff = Random.Range(0.1f, 10.0f);
        isOff = false;
    }

    private void LampOff()
    {
        lamp.SetActive(false);
        timeOff = Random.Range(0.1f, 10.0f);
        isOff = true;
    }
}
