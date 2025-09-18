using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleFollow : MonoBehaviour
{
    Vector3 diff;
    public Transform target;
    public float followSpeed;
    void Start()
    {
        diff = target.position - transform.position;
    }
    void LateUpdate()
    {
        transform.position = target.transform.position - diff;
    //     transform.position = Vector3.Lerp(
    //         transform.position, target.position - diff, Time.deltaTime * followSpeed
    // );        
    }
}
