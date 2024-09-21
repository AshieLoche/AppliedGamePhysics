using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetUp : MonoBehaviour
{

    public GameObject owo;
    public Transform[] hehe;

    // Start is called before the first frame update
    void Start()
    {
        owo.par
    }

    private void SetGrid(float xPos, float zPos)
    {
        
        hehe = owo.GetComponentsInChildren<Transform>();

        foreach (Transform t in hehe)
        {
            if (xPos >)
                t.position = new Vector3(xPos, t.position.y, zPos);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
