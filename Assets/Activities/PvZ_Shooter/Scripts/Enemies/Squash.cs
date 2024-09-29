using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Squash : MonoBehaviour, IEnemy
{

    #region Implemented Attributes
    public string Type => "Squash";
    public int Health => 125;
    public int Damage => 1000;
    public float ReachRange => 500f;
    public float SightRange => 1000f;
    public float PeripheralRange => 100f;
    #endregion

    #region Squash Attributes

    #region Game Object Components
    [Header("Game Object Components")]
    [SerializeField] Transform _player;
    [SerializeField] Rigidbody _squashRigidbody;
    #endregion

    #region Movement Attributes
    //[Header("Movement Attributes")]
    //#region Horizontal Movement

    //#endregion

    //#region Vertical Movement
    //[Header("Vertical Movement")]
    //[SerializeField] private float _verticalSpeed;
    //[SerializeField] private float _verticalTime;
    //[SerializeField] private float _verticalTimer;
    //private const float _verticalDistance = 150f;
    //private const float _verticalAcceleration = -9.81f;
    //#endregion

    //#region Depth Movement
    //[Header("Depth Movement")]
    //[SerializeField] private float _depthDistance;
    //[SerializeField] private float _depthSpeed;
    //#endregion

    //#region Projectile Movement
    //[Header("Projectile Movement")]
    //[SerializeField] private float _projectileTime = 0.25f;
    //[SerializeField] private float _projectileTimer;
    //[SerializeField] private bool _fullProjectile;
    //#endregion

    #endregion

    //#region Attack Attributes
    //[Header("Attack Attributes")]
    //[SerializeField] private float _attackSpeed = -1000f;
    //[SerializeField] private float _attackDelay = 1f;
    //[SerializeField] private float _attackDelayTimer;
    //[SerializeField] private float _squashDelay = 0.75f;
    //[SerializeField] private float _squashDelayTimer;
    //[SerializeField] private bool _attackPhase = false;
    //[SerializeField] private bool _isAttacking = false;
    //#endregion

    #region Visualizer Attributes
    [Header("Visualizer Attributes")]
    [SerializeField] private Vector3 _halfProjectileVisualizer;
    [SerializeField] private Vector3 _fullProjectileVisualizer;
    [SerializeField] private Vector3 _sightVisualizer;
    [SerializeField] private Vector3 _visibilityVisualizer;
    [SerializeField] private Vector3 _negativePeripheralVisualizer;
    [SerializeField] private Vector3 _positivePeripheralVisualizer;
    #endregion

    #endregion

    #region Squash Methods

    private Vector3 _originVector, _targetVector, _forwardVector,_direction;
    private void Start()
    {
        _squashRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RotateToPlayer();
    }


    public void RotateToPlayer()
    {

        GetVectors();
        GetDirection(_originVector, _targetVector);

        if (InPeripheral() && !PlayerHidden())
        {

            #region Rotate To Player
            Vector3 crossProduct = GetCrossProduct(_forwardVector, _direction);

            float crossProductMagnitude = GetMagnitude(crossProduct);

            Vector3 crossProductNormalized = GetNormalized(crossProduct, crossProductMagnitude);

            float rotationDirection = crossProductNormalized.y;

            float rotationSpeed = GetSpeed(distanceOrAngle: 50, time: 2);
            _squashRigidbody.angularVelocity = rotationDirection * rotationSpeed * transform.up;
            #endregion

        }
        else
        {
            _squashRigidbody.angularVelocity = Vector3.zero;
        }

    }

    public bool PlayerHidden()
    {
        if (Physics.Raycast(_originVector, _direction, out RaycastHit hit, SightRange))
        {
            Debug.Log(LayerMask.LayerToName(hit.collider.gameObject.layer) != "Player");
            return LayerMask.LayerToName(hit.collider.gameObject.layer) != "Player";
        }

        return false;
    }

    public bool InPeripheral()
    {
        float forwardMagnitude = GetMagnitude(_forwardVector);
        float directionMagnitude = GetMagnitude(_direction);

        Vector3 forwardNormalized = GetNormalized(_forwardVector, forwardMagnitude);
        Vector3 directionNormalized = GetNormalized(_direction, directionMagnitude);

        float dotProductNormalized = GetDotProduct(forwardNormalized, directionNormalized);

        return dotProductNormalized >= 0.5f;
    }

    public float GetSpeed(float distanceOrAngle, float time)
    {
        return distanceOrAngle / time;
    }

    public void GetVectors()
    {
        _originVector = transform.position;
        _targetVector = _player.position;
        _forwardVector = transform.forward;
    }

    public void GetDirection(Vector3 vectorA, Vector3 vectorB)
    {
        _direction = vectorB - vectorA;
    }

    public float GetMagnitude(Vector3 vector)
    {
        return Mathf.Sqrt(
            vector.x * vector.x + 
            vector.y * vector.y + 
            vector.z * vector.z);
    }

    public Vector3 GetNormalized(Vector3 vector, float magnitude)
    {
        return (magnitude > 0f) ? vector / magnitude : Vector3.zero;
    }

    public float GetDotProduct(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z);
    }

    public float GetDotProduct(float magnitudeA, float magnitudeB, float angle)
    {
        return magnitudeA * magnitudeB * MathF.Cos(angle);
    }

    public Vector3 GetCrossProduct(Vector3 vectorA, Vector3 vectorB)
    {
        return new Vector3(
            vectorA.y * vectorB.z - vectorA.z * vectorB.y,
            vectorA.z * vectorB.x - vectorA.x * vectorB.z,
            vectorA.x * vectorB.y - vectorA.y * vectorB.x);
    }

    //public void Attack(string attackType)
    //{
    //    if (attackType == "Half Projectile" || attackType == "Full Projectile")
    //    {
    //        _attackPhase = true;
    //    }

    //    if (_attackPhase)
    //    {

    //        transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().isTrigger = true;

    //        #region Horizontal Movement
    //        HorizontalMovement();
    //        #endregion

    //        if (!_isAttacking)
    //        {
    //            _attackDelayTimer = _attackDelay;

    //            #region Vertical Movement
    //            if (attackType == "Half Projectile")
    //            {
    //                VerticalMovement(projectileTimeLength: 1f);
    //            }
    //            else if (attackType == "Full Projectile")
    //            {
    //                VerticalMovement(projectileTimeLength: 0.5f);
    //            }
    //            #endregion

    //            _isAttacking = true;
    //        }

    //        if (_projectileTimer <= _projectileTime * ((attackType == "Half Projectile") ? 1f : 0.5f))
    //        {

    //            _projectileTimer += Time.fixedDeltaTime;

    //            _squashRigidbody.velocity = transform.forward * MathF.Abs(_depthSpeed) + transform.up * _squashRigidbody.velocity.y;

    //        }
    //        else
    //        {
    //            if (attackType == "Half Projectile")
    //            {
    //                _squashRigidbody.velocity = Vector3.zero;
    //                _attackDelayTimer -= Time.fixedDeltaTime;

    //                if (_attackDelayTimer >= 0f)
    //                {
    //                    _squashRigidbody.velocity = transform.up * 75f;
    //                    _squashRigidbody.angularVelocity = transform.up * 360f;
    //                }
    //                else
    //                {
    //                    _squashRigidbody.angularVelocity = Vector3.zero;
    //                    _squashRigidbody.velocity = transform.up * -Mathf.Sqrt((_attackSpeed * _attackSpeed) + 2 * _verticalAcceleration * -(_verticalDistance + 75f));

    //                    _verticalTimer += Time.fixedDeltaTime;
    //                    _verticalTime = (-(_attackSpeed) - Mathf.Sqrt((_attackSpeed * _attackSpeed) - 4 * (_verticalAcceleration / 2) * (_verticalDistance + 75f))) / (2f * _verticalAcceleration / 2f);

    //                    if (_verticalTimer >= _verticalTime + 0.01f)
    //                    {
    //                        _squashDelayTimer += Time.fixedDeltaTime;
    //                        _squashRigidbody.velocity = Vector3.zero;
    //                        _squashRigidbody.useGravity = false;

    //                        if (_squashDelayTimer >= _squashDelay)
    //                        {
    //                            gameObject.SetActive(false);
    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                if (!_fullProjectile)
    //                {
    //                    _squashRigidbody.velocity = Vector3.forward * _squashRigidbody.velocity.z + -Vector3.up * _squashRigidbody.velocity.y;
    //                    _fullProjectile = true;
    //                }


    //                //player.velocity = new Vector2(horizontalDisplacement / time, Mathf.Sqrt(2 * gravity * verticalDisplacement));
    //            }
    //        }
    //    }
    //}

    //private void VerticalMovement(float projectileTimeLength)
    //{
    //    float projectileTime = _projectileTime * projectileTimeLength;

    //    _verticalSpeed = (_verticalDistance - 0.5f * _verticalAcceleration * projectileTime * projectileTime) / projectileTime;

    //    _squashRigidbody.velocity = transform.up * _verticalSpeed;
    //}

    //private void HorizontalMovement()
    //{
    //    if (!_isAttacking)
    //    {
    //        _depthDistance = _player.position.z - transform.position.z;
    //    }

    //    _depthSpeed = _depthDistance / _projectileTime;
    //}

    //private string ReachPlayer()
    //{
    //    if (Physics.Raycast(transform.position, transform.forward, ReachRange / 2, 1 << LayerMask.NameToLayer("Player")))
    //    {
    //        return "Half Projectile";
    //    }
    //    else if (Physics.Raycast(transform.position, transform.forward, ReachRange, 1 << LayerMask.NameToLayer("Player")))
    //    {
    //        return "Full Projectile";
    //    }

    //    return "";
    //}

    private void OnDrawGizmos()
    {

        #region Half Projectile Visualizer
        _halfProjectileVisualizer = 
            transform.position + 
            transform.forward * ReachRange / 2;
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, _halfProjectileVisualizer);
        #endregion

        #region Full Projectile Visualizer
        _fullProjectileVisualizer = 
            _halfProjectileVisualizer + 
            transform.forward * ReachRange / 2;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_halfProjectileVisualizer, _fullProjectileVisualizer);
        #endregion

        #region Sight Visualizer
        _sightVisualizer =
            transform.position +
            transform.forward * (SightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(_fullProjectileVisualizer, _sightVisualizer);
        #endregion

        #region Visibility Visualizer
        _visibilityVisualizer = 
            transform.position +
            _player.position - transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, _visibilityVisualizer);
        #endregion

        #region Peripheral Vision Visualizer
        _negativePeripheralVisualizer =
            transform.position +
            transform.forward * (SightRange) -
            transform.right * (SightRange * Mathf.Tan(PeripheralRange / 2 * Mathf.PI / 180f));
        _positivePeripheralVisualizer = 
            transform.position + 
            transform.forward * (SightRange) + 
            transform.right * (SightRange * Mathf.Tan(PeripheralRange / 2 * Mathf.PI / 180f));
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, _negativePeripheralVisualizer);
        Gizmos.DrawLine(transform.position, _positivePeripheralVisualizer);
        #endregion
    }

    #endregion

}