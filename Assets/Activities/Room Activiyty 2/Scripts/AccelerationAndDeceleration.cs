using UnityEngine;
using NaughtyAttributes;

public class AccelerationAndDeceleration : MonoBehaviour
{

    #region Attributes
    #region GameObjects and Components
    [Header("GameObjects and Components")]
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Transform _checkpoint1TF;
    [SerializeField] private GameObject _midpointGO;
    [SerializeField] private Transform _checkpoint2TF;
    [SerializeField] private Transform _targetTF;
    private Vector3 _playerPos;
    private Vector3 _checkpoint1Pos;
    private Vector3 _checkpoint2Pos;
    private Vector3 _targetPos;
    #endregion

    #region Acceleration and Deceleration
    [Header("Acceleration and Deceleration")]
    [Header("Status")]
    [SerializeField] private bool _accelerateDecelerateStatus;
    public bool AccelerateDecelerateStatus => _accelerateDecelerateStatus;

    [Header("Inputted Values")]
    [SerializeField] private float _acceleration;
    [SerializeField] private float _deceleration;

    [Header("Calculated Values")]
    [SerializeField] private float _startingSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerationTime;
    [SerializeField] private float _decelerationTime;

    [Header("Actual Values")]
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _accelerationTimer;
    [SerializeField] private float _decelerationTimer;
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
        if (_accelerateDecelerateStatus)
        {
            AccelerateDecelerate();
        }
    }
    #endregion

    #region Method Buttons
    [Button]
    private void AccelerateAndDecelerate()
    {
        if (!_accelerateDecelerateStatus && !RoomActivity2_GameManager.Instance.GetProjectileStatus())
        {
            _checkpoint1TF.gameObject.SetActive(true);
            _midpointGO.SetActive(false);
            _checkpoint2TF.gameObject.SetActive(true);

            GetPositions();
            GetSpeeds();
            GetTimes();

            _accelerateDecelerateStatus = true;
        }
    }

    [Button]
    private void Reset()
    {
        _accelerateDecelerateStatus = false;

        _playerRB.position = _playerPos;
        _playerRB.velocity = Vector3.zero;
        _startingSpeed = _maxSpeed = _accelerationTime = _decelerationTime = _currentSpeed = _accelerationTimer = _decelerationTimer = 0f;
    }
    #endregion

    #region User Methods
    private void GetPositions()
    {
        _playerPos = transform.position;
        _checkpoint1Pos = _checkpoint1TF.position;
        _checkpoint2Pos = _checkpoint2TF.position;
        _targetPos = _targetTF.position;
    }

    private void GetSpeeds()
    {
        _startingSpeed = _playerRB.velocity.x;
        _maxSpeed = Mathf.Sqrt(Mathf.Pow(_playerRB.velocity.x, 2) + (2 * _acceleration * (Mathf.Abs(_checkpoint1Pos.x - _playerPos.x))));
    }

    private void GetTimes()
    {
        _accelerationTime = (-_startingSpeed + Mathf.Sqrt(Mathf.Pow(_startingSpeed, 2) - (4f * (0.5f * _acceleration) * (_playerPos.x - _checkpoint1Pos.x)))) / (2f * 0.5f * _acceleration);

        _decelerationTime = _accelerationTime;
    }

    private void AccelerateDecelerate()
    {

        if (_playerRB.position.x < _targetPos.x)
        {
            _currentSpeed = _playerRB.velocity.x;
        }

        if (_playerRB.position.x < _checkpoint1Pos.x)
        {
            _accelerationTimer += Time.fixedDeltaTime;
            _playerRB.velocity = Vector3.right * Mathf.Lerp(_startingSpeed, _maxSpeed, _accelerationTimer / ((_maxSpeed - _startingSpeed) / _acceleration));
        }
        else if (_playerRB.position.x >= _checkpoint1Pos.x && _playerRB.position.x < _checkpoint2Pos.x)
        {
            _playerRB.velocity = Vector3.right * _maxSpeed;
        }
        else if (_playerRB.position.x >= _checkpoint2Pos.x && _playerRB.velocity.x > 0f)
        {
            _decelerationTimer += Time.fixedDeltaTime;
            _playerRB.velocity = Vector3.right * Mathf.Lerp(_maxSpeed, _startingSpeed, _decelerationTimer / ((_startingSpeed - _maxSpeed) / _deceleration));
        }

    }
    #endregion
    #endregion

}