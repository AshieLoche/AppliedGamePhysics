using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UIElements;

public class AppliedPhysicsFormulae : MonoBehaviour
{

    [Header("Preliminaries")]
    [SerializeField] private Transform _player;
    [SerializeField] private bool correct = false;

    [Header("Origin and Target")]
    [SerializeField] private Vector2 _originV2;
    [SerializeField] private Vector2 _targetV2;
    [SerializeField] private Vector3 _originV3;
    [SerializeField] private Vector3 _targetV3;

    [Header("Direction")]
    [Header("Direction Formula")]
    [SerializeField] private string directionFormula = "Vector2/3 direction = target - origin";
    [Header("Vector 2: Direction")]
    [SerializeField] private Vector2 _directionV2;
    [Header("Vector 3: Direction")]
    [SerializeField] private Vector3 _directionV3;

    [Header("Magnitude")]
    [Header("Magnitude Formula (Pythogorean Theorem)")]
    [SerializeField] private string vector2MagnitudeFormula = "float vector2Magnitude = Mathf.Sqrt((vectorA.x * vectorA.x) + (vectorA.y * vectorA.y))";
    [SerializeField] private string vector3MagnitudeFormula = "float vector3Magnitude = Mathf.Sqrt((vectorA.x * vectorA.x) + (vectorA.y * vectorA.y) + (vectorA.z * vectorA.z))";
    [Header("Vector 2: Magnitude")]
    [SerializeField] private float _magnitudeV2;
    [Header("Vector 3: Magnitude")]
    [SerializeField] private float _magnitudeV3;

    [Header("Normalize")]
    [Header("Normalize Formula")]
    [SerializeField] private string normalizeFormula = "Vector2/3 normalizedVector2/3 = vectorA / vectorAMagnitude";
    [Header("Vector 2: Normalized")]
    [SerializeField] private Vector2 _normalizedV2;
    [Header("Vector 3: Normalized")]
    [SerializeField] private Vector3 _normalizedV3;

    [Header("Dot Product")]
    [Header("Vector 2: Dot Product (W/O Angle) Formula")]
    [SerializeField] private string vector2DotProductWithoutAngleFormela = "float vector2DotProductWithoutAngle = (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y)";
    [Header("Vector 3: Dot Product (W/O Angle) Formula")]
    [SerializeField] private string vector3DotProductWithoutAngleFormela = "float vectoreDotProductWithoutAngle = (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z)";
    [Header("Dot Product (W/ Angle) Formula")]
    [SerializeField] private string dotProductWithAngleFormela = "float dotProductWithAngle = magnitudeV2_A * magnitudeV2_B * Mathf.Cos(angle * Mathf.PI / 180f)";
    [Header("Vector 2: Dot Product (W/O Angle)")]
    [SerializeField] private float _dotProductWithoutAngleV2;
    [Header("Vector 3: Dot Product (W/O Angle)")]
    [SerializeField] private float _dotProductWithoutAngleV3;
    [Header("Dot Product (W/ Angle) Formula")]
    [SerializeField] private float _magnitudeV2_2;
    [SerializeField] private float _angleV2;
    [SerializeField] private float _dotProductWithAngleV2;
    [Header("Dot Product (W/ Angle) Formula")]
    [SerializeField] private float _magnitudeV3_2;
    [SerializeField] private float _angleV3;
    [SerializeField] private float _dotProductWithAngleV3;

    [Header("Cross Product")]
    [Header("Cross Product Formula")]
    [SerializeField] private string crossProductFormula = "Vector3 crossProduct = new Vector3(vectorA.y * vectorB.z - vectorA.z * vectorB.y, vectorA.z * vectorB.x - vectorA.x * vectorB.z, vectorA.x * vectorB.y - vectorA.y * vectorB.x)";
    [Header("Cross Product (Only Applicable in Vector 3)")]
    [SerializeField] private Vector3 _crossProduct;

    private void Start()
    {
        string superString = directionFormula + vector2MagnitudeFormula + vector3MagnitudeFormula + normalizeFormula + vector2DotProductWithoutAngleFormela + vector3DotProductWithoutAngleFormela + dotProductWithAngleFormela + crossProductFormula;
         superString = (superString.Length == 0) ? "" : "" ;
    }

    [Button]
    public void GetVector2Direction()
    {
        correct = false;

        _originV2 = transform.position;
        _targetV2 = _player.position;

        _originV3 = Vector3.zero;
        _targetV3 = Vector3.zero;

        _directionV2 = _targetV2 - _originV2;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;
    }

    [Button]
    public void GetVector3Direction()
    {
        correct = false;

        _originV2 = Vector2.zero;
        _targetV2 = Vector2.zero;

        _originV3 = transform.position;
        _targetV3 = _player.position;

        _directionV2 = Vector2.zero;
        _directionV3 = _targetV3 - _originV3;

        _magnitudeV2 = 0f;
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _dotProductWithAngleV2 = 0f;
        _dotProductWithAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;
    }

    [Button]
    public void GetVector2Magnitude()
    {
        correct = false;

        _originV2 = transform.position;
        _targetV2 = Vector2.zero;

        _originV3 = Vector3.zero;
        _targetV3 = Vector3.zero;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = Mathf.Sqrt((_originV2.x * _originV2.x) + (_originV2.y * _originV2.y));
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _dotProductWithAngleV2 = 0f;
        _dotProductWithAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (_originV2.magnitude == _magnitudeV2);
    }

    [Button]
    public void GetVector3Magnitude()
    {
        correct = false;

        _originV2 = Vector2.zero;
        _targetV2 = Vector2.zero;

        _originV3 = transform.position;
        _targetV3 = Vector3.zero;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = Mathf.Sqrt((_originV3.x * _originV3.x) + (_originV3.y * _originV3.y) + (_originV3.z * _originV3.z));

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (_originV3.magnitude == _magnitudeV3);
    }

    [Button]
    public void GetNormalizedVector2()
    {
        correct = false;

        _originV2 = transform.position;
        _targetV2 = Vector2.zero;

        _originV3 = Vector3.zero;
        _targetV3 = Vector3.zero;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = Mathf.Sqrt((_originV2.x * _originV2.x) + (_originV2.y * _originV2.y));
        _magnitudeV3 = 0f;

        _normalizedV2 = (_magnitudeV2 > 0) ? _originV2 / _magnitudeV2 : Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (_originV2.normalized == _normalizedV2);
    }

    [Button]
    public void GetNormalizedVector3()
    {
        correct = false;

        _originV2 = Vector2.zero;
        _targetV2 = Vector2.zero;

        _originV3 = transform.position;
        _targetV3 = Vector3.zero;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = Mathf.Sqrt((_originV3.x * _originV3.x) + (_originV3.y * _originV3.y) + (_originV3.z * _originV3.z));

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = (_magnitudeV3 > 0) ? _originV3 / _magnitudeV3 : Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (_originV3.normalized == _normalizedV3);
    }

    [Button]
    public void GetVector2DotProductWithoutAngle()
    {
        correct = false;

        _originV2 = transform.position;
        _targetV2 = _player.position;

        _originV3 = Vector3.zero;
        _targetV3 = Vector3.zero;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = (_originV2.x * _targetV2.x) + (_originV2.y * _targetV2.y);
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (Vector2.Dot(_originV2, _targetV2) == _dotProductWithoutAngleV2);
    }

    [Button]
    public void GetVector3DotProductWithoutAngle()
    {
        correct = false;

        _originV2 = Vector2.zero;
        _targetV2 = Vector2.zero;

        _originV3 = transform.position;
        _targetV3 = _player.position;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = (_originV3.x * _targetV3.x) + (_originV3.y * _targetV3.y) + (_originV3.z * _targetV3.z);

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (Vector3.Dot(_originV3, _targetV3) == _dotProductWithoutAngleV3);
    }

    [Button]
    public void GetVector2DotProductWithAngle()
    {
        correct = false;

        _originV2 = transform.position;
        _targetV2 = _player.position;

        _originV3 = Vector3.zero;
        _targetV3 = Vector3.zero;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = Mathf.Sqrt((_originV2.x * _originV2.x) + (_originV2.y * _originV2.y));
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = (_originV2.x * _targetV2.x) + (_originV2.y * _targetV2.y);
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 =
        Mathf.Sqrt((_targetV2.x * _targetV2.x) + (_targetV2.y * _targetV2.y));
        _angleV2 = Mathf.Acos(_dotProductWithoutAngleV2 / (_magnitudeV2 * _magnitudeV2_2)) * 180f / Mathf.PI;
        _dotProductWithAngleV2 = Mathf.Round(_magnitudeV2 * _magnitudeV2_2 * Mathf.Cos(_angleV2 * Mathf.PI / 180f));

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = Vector3.zero;

        correct = (Vector2.Dot(_originV2, _targetV2) == _dotProductWithAngleV2);
    }

    [Button]
    public void GetVector3DotProductWithAngle()
    {
        correct = false;

        _originV2 = Vector2.zero;
        _targetV2 = Vector2.zero;

        _originV3 = transform.position;
        _targetV3 = _player.position;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = Mathf.Sqrt((_originV3.x * _originV3.x) + (_originV3.y * _originV3.y) + (_originV3.z * _originV3.z));

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = (_originV3.x * _targetV3.x) + (_originV3.y * _targetV3.y) + (_originV3.z * _targetV3.z);

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = Mathf.Sqrt((_targetV3.x * _targetV3.x) + (_targetV3.y * _targetV3.y) + (_targetV3.z * _targetV3.z));
        _angleV3 = Mathf.Acos(_dotProductWithoutAngleV3 / (_magnitudeV3 * _magnitudeV3_2)) * 180f / Mathf.PI;
        _dotProductWithAngleV3 = Mathf.Round(_magnitudeV3 * _magnitudeV3_2 * Mathf.Cos(_angleV3 * Mathf.PI / 180f));

        _crossProduct = Vector3.zero;

        correct = (Vector3.Dot(_originV3, _targetV3) == _dotProductWithAngleV3);
    }

    [Button]
    public void GetCrossProduct()
    {
        correct = false;

        _originV2 = Vector2.zero;
        _targetV2 = Vector2.zero;

        _originV3 = transform.position;
        _targetV3 = _player.position;

        _directionV2 = Vector2.zero;
        _directionV3 = Vector3.zero;

        _magnitudeV2 = 0f;
        _magnitudeV3 = 0f;

        _normalizedV2 = Vector2.zero;
        _normalizedV3 = Vector3.zero;

        _dotProductWithoutAngleV2 = 0f;
        _dotProductWithoutAngleV3 = 0f;

        _magnitudeV2_2 = 0f;
        _angleV2 = 0f;
        _dotProductWithAngleV2 = 0f;

        _magnitudeV3_2 = 0f;
        _angleV3 = 0f;
        _dotProductWithAngleV3 = 0f;

        _crossProduct = new Vector3(_originV3.y * _targetV3.z - _originV3.z * _targetV3.y, _originV3.z * _targetV3.x - _originV3.x * _targetV3.z, _originV3.x * _targetV3.y - _originV3.y * _targetV3.x);

        correct = (Vector3.Cross(_originV3, _targetV3) == _crossProduct);
    }

}
