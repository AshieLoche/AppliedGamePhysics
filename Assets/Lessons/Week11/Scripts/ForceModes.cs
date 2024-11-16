using System.Collections.Generic;
using UnityEngine;

public class ForceModes : MonoBehaviour
{

    private List<Rigidbody> _rbs;
    private float _force;
    private Rigidbody _rb;
    private bool _running;

    private void Awake()
    {
        Week11_GameManager.OnRunEvent.AddListener(Run);
        Week11_GameManager.OnStopEvent.AddListener(Stop);
        Week11_GameManager.OnSetForceEvent.AddListener(SetForce);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        for (int i = 0; i < _rbs.Count; i++)
        {
            _rbs[i].AddForce(transform.up * _force, i switch
            {
                0 => ForceMode.Force,
                1 => ForceMode.Acceleration,
                2 => ForceMode.Impulse,
                3 => ForceMode.VelocityChange,
                _ => ForceMode.Force
            });
        }


        if (_running)
        {
            if (name.Contains("Manual"))
            {
                _rb.velocity += name switch
                {
                    "Force Manual" => transform.up * (_force * Time.deltaTime / _rb.mass),
                    "Impulse Manual" => transform.up * (_force / _rb.mass),
                    "Acceleration Manual" => transform.up * (_force * Time.deltaTime),
                    "VelocityChange Manual" => transform.up * _force,
                    _ => Vector3.zero
                };
            }
            else if(name.Contains("Automatic"))
            {
                _rb.AddForce(transform.up * _force, name switch
                {
                    "Force Automatic" => ForceMode.Force,
                    "Impulse Automatic" => ForceMode.Impulse,
                    "Acceleration Automatic" => ForceMode.Acceleration,
                    "VelocityChange Automatic" => ForceMode.VelocityChange,
                    _ => ForceMode.Force
                });
            }
        }
    }

    private void Run()
    {
        _running = true;
    }

    private void Stop()
    {
        _running = false;
    }

    private void SetForce(float force)
    {
        _force = force;
    }

}