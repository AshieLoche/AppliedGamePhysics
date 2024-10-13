using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivity2_GameManager : MonoBehaviour
{

    public static RoomActivity2_GameManager Instance;

    [SerializeField] private AccelerationAndDeceleration _accelerationAndDeceleration;
    [SerializeField] private ProjectileMotion _projectileMotion;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Destroy(this);
        }

    }

    public bool GetProjectileStatus()
    {
        return _projectileMotion.HalfProjectileStatus || _projectileMotion.FullProjectileStatus;
    }

    public bool GetAccelerationDecelerationStatus()
    {
        return _accelerationAndDeceleration.AccelerateDecelerateStatus;
    }

}
