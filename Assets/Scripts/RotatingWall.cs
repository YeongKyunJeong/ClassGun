using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    public Rigidbody rbody;
    public float rotationY;
  
    // is Kinematic : �ٸ� �ܺ� �������� �������� �ʰ� rigidbody ������ �����θ� ������ (ex: �浹�ص� �и��� ����)

    void FixedUpdate()
    {
        rbody.MoveRotation(rbody.rotation * Quaternion.Euler(new Vector3(0,rotationY,0)));
    }
}
