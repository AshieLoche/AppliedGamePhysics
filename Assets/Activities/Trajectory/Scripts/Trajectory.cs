using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    [SerializeField]
    private float horizontalDisplacement, verticalDisplacement, time;
    [SerializeField]
    private Rigidbody2D player;
    private const float gravity = 9.81f;

    [Button]
    public void ProjectileMovement()
    {
        player.velocity = new Vector2(horizontalDisplacement / time, Mathf.Sqrt(2 * gravity * verticalDisplacement));
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

}
