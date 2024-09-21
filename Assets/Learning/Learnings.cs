using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Learning : MonoBehaviour
{
    [Header("Ball Model")]
    [SerializeField] private Rigidbody _ball;

    [Header("Angle and Power")]
    [Range(0, 90)]
    [SerializeField] private float _angle;
    [SerializeField] private float _power;

    private Vector2 _initialVelocity;
    private Vector2 _initialPosition;
    private float _time;
    private bool _isLaunched;

    private void Launch()
    {

        _initialVelocity = new Vector2(Mathf.Cos(_angle * Mathf.PI/180), Mathf.Sin(_angle * Mathf.PI / 180)) * _power;
        _initialPosition = new Vector2(_ball.position.x, _ball.position.y);

        _isLaunched = true;

    }

    private float KinematicEquation(float acceleration, float velocity, float position, float time)
    {
        return 0.5f * acceleration * (time  * time) + velocity * time + position;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !_isLaunched)
        {
            Launch();
        }

        if (_isLaunched)
        {


            _time = Time.deltaTime;

            float newBallX = KinematicEquation(0, _initialVelocity.x, _initialPosition.x, _time);
            float newBallY = KinematicEquation(-9.81f, _initialVelocity.y, _initialPosition.y, _time);

            _ball.position = new Vector3(newBallX, newBallY, _ball.position.z);

            Debug.Log(_initialPosition);
            Debug.Log(new Vector3(newBallX, newBallY, _ball.position.z));
            Debug.Log("YIPPIE");
        }

    }

}
