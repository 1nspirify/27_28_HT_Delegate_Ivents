using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsListener : MonoBehaviour
{
   [SerializeField] private EventExample _eventExample;
   private void Awake()
   {
      _eventExample.MyEventExample += OnEventExample;
   }

   private void OnEventExample()
   {
      Debug.Log("EventExampleExecuted");
   }
}
