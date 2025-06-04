using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MyDelegate();
public class EventExample : MonoBehaviour
{
    public event MyDelegate MyEventExample;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MyEventExample?.Invoke(); 
    }
}
