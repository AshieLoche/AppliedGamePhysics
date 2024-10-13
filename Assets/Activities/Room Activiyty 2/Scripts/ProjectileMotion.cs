using UnityEngine;
using NaughtyAttributes;

public class ProjectileMotion : MonoBehaviour
{
    #region Attributes
    #region GameObjects and Components
    [Header("GameObjects and Components")]
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private GameObject _checkpoint1GO;
    [SerializeField] private Transform _midpointTF;
    [SerializeField] private GameObject _checkpoint2GO;
    [SerializeField] private Transform _targetTF;
    private Vector3 _playerPos;
    private Vector3 _midpointPos;
    private Vector3 _targetPos;
    #endregion

    #region Projectile Motion
    [Header("Projectile Motion")]
    [Header("Status")]
    [SerializeField] private bool _halfProjectileStatus;
    [SerializeField] private bool _fullProjectileStatus;
    public bool HalfProjectileStatus => _halfProjectileStatus;
    public bool FullProjectileStatus => _fullProjectileStatus;

    [Header("Horizontal Movement")]
    [SerializeField] private float _horizontalSpeed;

    [Header("Vertical Movement")]
    [SerializeField] private float _verticalDisplacement;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private const float _gravity = -9.8f;
    #endregion

    #endregion

    #region Methods
    #region Native Methods
    private void Start()
    {
        if (_playerRB == null)
        {
            _playerRB = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        //if (_accelerateDecelerate)
        //{
        //    AccelerateDecelerate();
        //}
    }
    #endregion

    #region Method Buttons
    [Button]
    private void HalfProjectile()
    {
        SetUp();

        //_halfProjectileStatus = true;
        //_fullProjectileStatus = false;
        //_horizontalSpeed = Mathf.Sqrt((-2 * _gravity * Mathf.Abs(_midpointPos.x - _playerPos.x))/Mathf.Sin());

        _verticalSpeed = Mathf.Sqrt(-2 * _gravity * _verticalDisplacement);

        _playerRB.velocity = Vector3.right * _horizontalSpeed + Vector3.up * _verticalSpeed;
    }

    [Button]
    private void Reset()
    {
        _halfProjectileStatus = false;
        _fullProjectileStatus = false;

        _playerRB.position = _playerPos;
        //_startingSpeed = _maxSpeed = _accelerationTime = _decelerationTime = _currentSpeed = _accelerationTimer = _decelerationTimer = 0f;
    }
    #endregion

    #region User Methods
    private void SetUp()
    {
        _checkpoint1GO.SetActive(false);
        _midpointTF.gameObject.SetActive(true);
        _checkpoint2GO.SetActive(false);

        GetPositions();
        //GetSpeeds();
        //GetTimes();
    }

    private void GetPositions()
    {
        _playerPos = transform.position;
        _midpointPos =_midpointTF.position;
        _targetPos = _targetTF.position;
    }
    #endregion
    #endregion
}
