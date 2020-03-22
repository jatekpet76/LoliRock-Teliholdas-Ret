using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;

    Vector3 _originalPos;
    Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _originalPos = transform.position;
        _offset = _originalPos - playerController.gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerController.player.transform.position + _offset;
    }
}
