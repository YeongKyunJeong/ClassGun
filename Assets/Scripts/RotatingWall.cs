using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    public Rigidbody rbody;
    public float rotationY;
  
    // is Kinematic : 다른 외부 요인으로 움직이지 않고 rigidbody 본인의 물리로만 움직임 (ex: 충돌해도 밀리지 않음)

    void FixedUpdate()
    {
        rbody.MoveRotation(rbody.rotation * Quaternion.Euler(new Vector3(0,rotationY,0)));
    }
}
