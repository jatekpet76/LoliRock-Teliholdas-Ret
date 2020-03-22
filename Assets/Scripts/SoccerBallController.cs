using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallController : MonoBehaviour
{
    public PlayerController playerController;

    LineRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            ResetPosition();
        }

        DrawBallPosition();
    }

    void ResetPosition()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

        transform.position = new Vector3(0f, 5f, 0f);
    }

    void DrawBallPosition()
    {
        _renderer.positionCount = 2;
        _renderer.SetPositions(new Vector3[2] {playerController.player.transform.position, transform.position} );
        _renderer.enabled = true;
    }
}
