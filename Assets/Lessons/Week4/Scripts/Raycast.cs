using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] private float raycastlength;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, new Vector3(.707f, .707f), raycastlength, 1 << LayerMask.NameToLayer("Ground")))
        {
            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("No Hit");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (new Vector3(.707f, .707f) * raycastlength));
    }

}
