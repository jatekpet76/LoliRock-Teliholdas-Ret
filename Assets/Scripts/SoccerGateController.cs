using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoccerGateController : MonoBehaviour
{
    public GoalEvent goalEvent;
    public GateColor gateColor = GateColor.RED;

    void Start() { }
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") {
            goalEvent.Invoke(gateColor);
        }
    }

    void OnTriggerExit(Collider other)
    {
    }
}

[System.Serializable]
public class GoalEvent : UnityEvent<GateColor> { }
