using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform FollowTarget;
    public Vector3 TargetOffset;
    public float MoveSpeed = 2f;

    private Transform _myTransform;

    private void Start()
    {
        _myTransform = transform;
    }

    private void LateUpdate()
    {

        if (FollowTarget != null)
            _myTransform.position = Vector3.Lerp(_myTransform.position, FollowTarget.position + TargetOffset, MoveSpeed * Time.deltaTime);
    }
}
