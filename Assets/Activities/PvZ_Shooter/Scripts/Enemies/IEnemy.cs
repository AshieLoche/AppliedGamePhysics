using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IEnemy
{

    string Type {  get; }
    int Health { get; }
    int Damage { get; }
    float ReachRange { get; }
    float SightRange { get; }
    float PeripheralRange { get; }

    void OnDrawGizmos();
    void Attack();

}
