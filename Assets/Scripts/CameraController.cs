using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BallController ball;
    private float offset;

    // Start is called before the first frame update
    void Awake()
    {
        offset = transform.position.y - ball.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = ball.transform.position.y + offset;
        transform.position = currentPos;
    }
}
