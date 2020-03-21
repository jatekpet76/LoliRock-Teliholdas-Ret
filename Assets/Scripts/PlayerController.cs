using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    Rigidbody _rigidbody;
    NavMeshAgent _agent;
    Transform _transform;

    void Start()
    {
        SetComponents();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            // var hit = Physics.Raycast(Camera.main.transform.position, Input.mousePosition, out hitInfo, 100);

            if (Physics.Raycast(ray, out hit, 100))
            {
                var distance = Vector3.Distance(transform.position, hit.point);


                _agent.destination = hit.point;
            }
        }
    }

    void SetComponents()
    {
        _transform = player.GetComponent<Transform>();
        _rigidbody = player.GetComponent<Rigidbody>();
        _agent = player.GetComponent<NavMeshAgent>();
    }
}
