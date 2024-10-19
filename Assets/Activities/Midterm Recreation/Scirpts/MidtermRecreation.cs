using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Threading;
using TMPro;

public class MidtermRecreation : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private TextMeshProUGUI _planeDetails;
    [SerializeField] private float _minimumspeed;
    [SerializeField] private float _maximumSpeed;
    [SerializeField] private float _accelerationTime;
    [SerializeField] private float _positiveMultiplier;
    [SerializeField] private float _negativeMultiplier;
    [SerializeField] private float _tiltAngle;
    [SerializeField] private float _smooth;

    private Rigidbody2D _planeRB2;
    private float _timer, _newMinimumSpeed, _newMaximumSpeed;
    private bool _accelerating, _accelerated;

    // Start is called before the first frame update
    void Start()
    {
        if (_planeRB2 == null)
        {
            _planeRB2 = GetComponent<Rigidbody2D>();
        }

        Drag();
        Fly();
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
        PlaneUI();
        Drag();
        Rotate();
        Cam();
    }

    private void Fly()
    {
        _planeRB2.velocity = transform.right * _newMinimumSpeed;
    }

    private void Accelerate()
    {
        _timer += Time.deltaTime;
        _planeRB2.velocity = transform.right * Mathf.Lerp(_newMinimumSpeed, _newMaximumSpeed, _timer / _accelerationTime);
    }

    private void Decelerate()
    {
        _timer += Time.deltaTime;
        _planeRB2.velocity = transform.right * Mathf.Lerp(_newMaximumSpeed, _newMinimumSpeed, _timer / _accelerationTime);
    }

    private void Rotate()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * _tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0f, 0f, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
    }

    private void Drag()
    {
        if (Vector2.Dot(Vector2.up, transform.up) < 1f && transform.up.x > 0f)
        {
            _newMinimumSpeed = _minimumspeed * _positiveMultiplier;
            _newMaximumSpeed = _maximumSpeed * _positiveMultiplier;
        }
        else if (Vector2.Dot(Vector2.up, transform.up) < 1f && transform.up.x < 0f)
        {
            _newMinimumSpeed = _minimumspeed * _negativeMultiplier;
            _newMaximumSpeed = _maximumSpeed * _negativeMultiplier;
        }
        else
        {
            _newMinimumSpeed = _minimumspeed;
            _newMaximumSpeed = _maximumSpeed;
        }
    }

    private void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            _timer = 0f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Accelerate();
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Decelerate();
        }
    }

    private void PlaneUI()
    {
        _planeDetails.text = $"Velocity: {_planeRB2.velocity.x} m/s";
    }

    private void Cam()
    {
        _camera.transform.position = _planeRB2.transform.position + _camera.transform.forward * -10f;
    }
}
