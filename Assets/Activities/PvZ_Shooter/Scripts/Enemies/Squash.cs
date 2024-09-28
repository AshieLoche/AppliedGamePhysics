using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squash : MonoBehaviour, IEnemy
{

    public string Type => "Squash";
    public int Health => 125;
    public int Damage => 1000;
    public float ReachRange => 500;

    public float SightRange => 1000;

    public float PeripheralRange => 100;

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void OnDrawGizmos()
    {

        #region Peripheral Vision
        Vector3 negativePeripheral = (SightRange * Mathf.Tan(PeripheralRange / 2 / 180 * Mathf.PI) * -transform.right) + (SightRange * transform.forward);
        Vector3 positivePerihperal = (SightRange * Mathf.Tan(PeripheralRange / 2 / 180 * Mathf.PI) * transform.right) + (SightRange * transform.forward);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, negativePeripheral);
        Gizmos.DrawLine(transform.position, positivePerihperal);
        #endregion

        //#region 
    }

}
