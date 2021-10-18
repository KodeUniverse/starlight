using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 10f, -60f);
    [SerializeField] float distanceDamp = 100f;
    //[SerializeField] float rotationalDamp = 10f;
    public Vector3 velocity = Vector3.zero;

    
    void Start()
    {
        transform.position = target.position;
    }

    
    void Update()
    {
        
    }
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + (target.rotation * defaultDistance);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, distanceDamp * Time.deltaTime);
        transform.LookAt(target, target.up);
        transform.rotation *= Quaternion.Euler(-5, 0, 0);
    }
} 
