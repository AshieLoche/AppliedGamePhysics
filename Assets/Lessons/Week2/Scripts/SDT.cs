using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SDT : MonoBehaviour
{

    #region GameObject and Components
    [Header("GameObject and Components")]
    [SerializeField] private Rigidbody _playerRB;
    private Vector3 _pos;
    #endregion

    #region Speed
    [Header("Speed")]
    [SerializeField] private float _distance;
    [SerializeField] private float _speedTime;
    [SerializeField] private float _speed;
    [SerializeField] private float _currentSpeed;
    #endregion

    #region Acceleration
    [Header("Acceleration")]
    [SerializeField] private float _acceleration;
    [SerializeField] private float _accelerationTime;
    [SerializeField] private float _initialVelocity;
    [SerializeField] private float _finalVelocity;
    private float _timer;
    private bool _accelerate = false;
    #endregion


    private void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _pos = transform.position;
    }

    [Button]
    public void Run()
    {
        _playerRB.velocity = Vector3.right * _speed;
    }

    [Button]
    public void Accelerate()
    {
        _accelerate = true;
    }

    [Button]
    public void Restart()
    {
        _accelerate = false;
        _playerRB.velocity = Vector3.zero;
        transform.position = _pos;
    }

    // Update is called once per frame
    void Update()
    {
        GetValues();

        if (_accelerate)
        {
            _timer += Time.deltaTime;

            _playerRB.velocity = Vector3.right * Mathf.Lerp(_playerRB.velocity.z, _finalVelocity,  _timer / _accelerationTime);
        }
    }

    private void GetValues()
    {
        _speed = _distance / _speedTime;
        _initialVelocity = _speed;
        _finalVelocity = _initialVelocity + _acceleration * _accelerationTime;
        _currentSpeed = _playerRB.velocity.x;
    }

}
