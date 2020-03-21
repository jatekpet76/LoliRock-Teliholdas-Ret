using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentDebugger : MonoBehaviour
{
    LineRenderer _renderer;
    [SerializeField] NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.hasPath)
        {
            _renderer.positionCount = _agent.path.corners.Length;
            _renderer.SetPositions(_agent.path.corners);
            _renderer.enabled = true;
        }
        else
        {
            _renderer.enabled = false;
        }
    }
}
