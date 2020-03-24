using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTeamController : MonoBehaviour
{
    GameObject[] _enemies;
    GameObject[] _balls;
    GameObject[] _players;
    GameObject[] _gates;

    GameObject _enemyGate;
    GameObject _playerGate;

    public float pingDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _enemies = GameObject.FindGameObjectsWithTag("EnemyPlayer");
        _balls = GameObject.FindGameObjectsWithTag("Ball");
        _players = GameObject.FindGameObjectsWithTag("Player");

        _gates = GameObject.FindGameObjectsWithTag("Gate");
        
        if (_gates[0].GetComponent<SoccerGateController>().gateColor == GateColor.RED)
        {
            _enemyGate = _gates[0];
            _playerGate = _gates[1];
        } else
        {
            _enemyGate = _gates[1];
            _playerGate = _gates[0];
        }

        StartCoroutine(MainLoop());
    }

    IEnumerator MainLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(pingDuration);

            foreach (var enemy in _enemies)
            {
                ThinkWhatToDo(enemy);
            }
        }
    }

    void ThinkWhatToDo(GameObject enemy)
    {
        // var status = EnemyStatus.NEAREST_BALL;

        var status = (EnemyStatus) UnityEngine.Random.Range(0, 9);

        if (status == EnemyStatus.NEAREST_BALL)
        {
            var target = LocateNearest(enemy, _balls);

            enemy.GetComponent<NavMeshAgent>().destination = target.transform.position;
        } 
        else if (status == EnemyStatus.NEAREST_PLAYER)
        {
            var target = LocateNearest(enemy, _players);

            enemy.GetComponent<NavMeshAgent>().destination = target.transform.position;
        }
        else if (status == EnemyStatus.OWN_GATE)
        {
            enemy.GetComponent<NavMeshAgent>().destination = _enemyGate.transform.position;
        }
        else if (status == EnemyStatus.PLAYER_GATE)
        {
            enemy.GetComponent<NavMeshAgent>().destination = _playerGate.transform.position;
        }
        else if (status == EnemyStatus.NEAREST_PLAYER_BALL)
        {
            var ball = LocateNearestPlayerBall(enemy);

            enemy.GetComponent<NavMeshAgent>().destination = ball.transform.position;
        }
        else if (status == EnemyStatus.NEAREST_ATTACKER)
        {
            var player = LocateNearest(_enemyGate, _players);

            enemy.GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
        else if (status == EnemyStatus.NEAREST_GATE_BALL)
        {
            var ball = LocateNearest(_enemyGate, _balls);

            enemy.GetComponent<NavMeshAgent>().destination = ball.transform.position;
        }
        else if (status == EnemyStatus.ATTACK_GATE_BALL)
        {
            var ball = LocateNearest(_playerGate, _balls);

            enemy.GetComponent<NavMeshAgent>().destination = ball.transform.position;
        }
    }

    GameObject LocateNearestPlayerBall(GameObject baseObj)
    {
        GameObject found = null;
        float distance = Mathf.Infinity;

        foreach (var player in _players)
        {
            foreach (var ball in _balls)
            {
                var curDist = Vector3.Distance(ball.transform.position, player.transform.position);

                if (curDist < distance)
                {
                    distance = curDist;
                    found = ball;
                }
            }
        }

        return found;
    }

    GameObject LocateNearest(GameObject gameObject, GameObject[] targets)
    {
        float distance = Mathf.Infinity;
        GameObject found = null;

        foreach (var target in targets)
        {
            var curDist = Vector3.Distance(gameObject.transform.position, target.transform.position);

            if (curDist < distance && target.transform.position.y > 0)
            {
                distance = curDist;
                found = target;
            }
        }

        return found;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

enum EnemyStatus
{
    NEAREST_BALL = 0, NEAREST_PLAYER_BALL = 1, OWN_GATE = 2, PLAYER_GATE = 3, NEAREST_PLAYER = 4, NEAREST_ATTACKER = 5, NEAREST_GATE_BALL = 6, ATTACK_GATE_BALL = 7
}
