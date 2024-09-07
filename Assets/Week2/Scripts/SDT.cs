using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SDT : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time;
    [SerializeField] private float distance;
    private float elapsedTime;
    private bool begin = false;

    [Button]
    public void Run()
    {
        elapsedTime = 0;
        begin = true;
    }

    [Button]
    public void Restart()
    {
        elapsedTime = 0;
        begin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            speed = distance / time;
            transform.position += new Vector3(distance * Time.deltaTime / time, 0, 0);
        }
    }

}
