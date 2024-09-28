using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SDT : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float distance;
    private bool begin = false;

    [Button]
    public void Run()
    {
        begin = true;
    }

    [Button]
    public void Restart()
    {
        begin = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (begin)
        {
            transform.position += new Vector3(distance * Time.deltaTime / time, 0, 0);
        }
    }

}
