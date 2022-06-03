using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamController : MonoBehaviour
{
    [SerializeField] private Transform _trackingTarget;
    void Update()
    {
        transform.position = new Vector3(_trackingTarget.position.x, _trackingTarget.position.y, transform.position.z);
    }
}

