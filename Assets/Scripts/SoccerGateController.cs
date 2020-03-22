using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoccerGateController : MonoBehaviour
{
    public GoalEvent goalEvent;
    public int gatePos = 0;

    void Start() { }
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") {
            goalEvent.Invoke(gatePos);
        }
    }

    void OnTriggerExit(Collider other)
    {
    }
}

[System.Serializable]
public class GoalEvent : UnityEvent<int> { }
