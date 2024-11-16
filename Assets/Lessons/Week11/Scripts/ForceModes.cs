using UnityEngine;

public class ForceModes : MonoBehaviour
{

    private float _force;
    private Rigidbody _rb;
    private ForceMode _forceMode;
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
        if (_running)
        {
            if (name.Contains("(1)"))
            {
                _rb.velocity += name switch
                {
                    "Force (1)" => transform.up * (_force * Time.deltaTime / _rb.mass),
                    "Impulse (1)" => transform.up * (_force / _rb.mass),
                    "Acceleration (1)" => transform.up * (_force * Time.deltaTime),
                    "VelocityChange (1)" => transform.up * _force,
                    _ => Vector3.zero
                };
            }
            else
            {
                _forceMode = name switch
                {
                    "Force" => ForceMode.Force,
                    "Impulse" => ForceMode.Impulse,
                    "Acceleration" => ForceMode.Acceleration,
                    "VelocityChange" => ForceMode.VelocityChange,
                    _ => ForceMode.Force
                };

                _rb.AddForce(transform.up * _force, _forceMode);
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