using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoccerPlayerController : MonoBehaviour
{
    public GameObject ball;
    public int kickPower = 100;
    public float ballDistance = 1.5f;

    PlayerController _playerController;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_playerController.player.transform.position, ball.transform.position) < ballDistance)
        {
            var agent = _playerController.player.GetComponent<NavMeshAgent>();
            
            // _playerController.player.transform.forward
            ball.GetComponent<Rigidbody>().AddForce(agent.velocity.normalized * kickPower * agent.velocity.magnitude, ForceMode.Impulse);
        }
    }

}
