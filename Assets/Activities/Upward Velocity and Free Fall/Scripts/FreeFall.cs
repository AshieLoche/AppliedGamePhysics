using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FreeFall : MonoBehaviour
{

    [SerializeField]
    private float predictedTime, actualTime;
    [SerializeField]
    private Rigidbody2D enemy;
    [SerializeField]
    private Transform floor;
    private RaycastHit2D hit;
    private bool run = false;

    // Start is called before the first frame update
    void Start()
    {

        run = true;
        actualTime = 0;

        enemy.bodyType = RigidbodyType2D.Dynamic;
        hit = Physics2D.Raycast(enemy.transform.position, Vector2.down,
        Vector2.Distance(enemy.transform.position, floor.position), LayerMask.GetMask("Floor"));

        if (hit.collider != null)
        {
            predictedTime = Mathf.Sqrt((2 * Vector2.Distance(enemy.transform.position, hit.point)) / 9.81f);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (enemy.velocity.y == 0)
        {
            run = false;
        }

        if (run)
        {
            actualTime += Time.deltaTime;
        }

    }
}
