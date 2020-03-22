using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoccerPlayerController : MonoBehaviour
{
    public int kickPower = 100;
    public float ballDistance = 1.5f;

    GameObject[] _balls;
    PlayerController _playerController;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();

        _balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var ball in _balls)
        {
            KickBalls(ball);
        }
    }

    private void KickBalls(GameObject ball)
    {
        if (Vector3.Distance(_playerController.player.transform.position, ball.transform.position) < ballDistance)
        {
            var agent = _playerController.player.GetComponent<NavMeshAgent>();

            // _playerController.player.transform.forward
            ball.GetComponent<Rigidbody>().AddForce(agent.velocity.normalized * kickPower * agent.velocity.magnitude, ForceMode.Impulse);
        }
    }

    public void OnGoal(GateColor gateColor)
    {
        Debug.Log("GOALLLL!!!!! " + gateColor);
    }
}
