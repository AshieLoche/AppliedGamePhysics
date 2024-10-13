using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardVelocity : MonoBehaviour
{

    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]
    private Transform target;

    [Button]
    public void Run()
    {

        verticalSpeed = Mathf.Sqrt(2 * -Physics2D.gravity.y * Vector2.Distance(player.transform.position, target.position));
        player.velocity = new Vector2(0, verticalSpeed);

    }

}
