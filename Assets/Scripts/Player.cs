using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody rbody;
    public Vector3 moveDir;
    public float moveSpeed;
    public FixedJoystick fixedJoystick;
    public GameObject bulletPrefab;
    public Transform muzzle;
    // Update is called once per frame
    void Update()
    {
        float x =/* fixedJoystick.Horizontal*/ +Input.GetAxisRaw("Horizontal");
        float z =/* fixedJoystick.Vertical */+Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(x, 0, z);
        moveDir.Normalize();            // 대각선으로 움직여도 속력이 같도록

        // Rotaion

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit,
            float.MaxValue, 1 << LayerMask.NameToLayer("MouseRay")))
        {
            Vector3 lookDir = hit.point - transform.position;
            lookDir.y = 0;
            transform.LookAt(transform.position + lookDir);
        }

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, muzzle.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + moveDir * moveSpeed);
    }

}

