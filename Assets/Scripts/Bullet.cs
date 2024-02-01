using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody rbody;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rbody.AddForce(force*transform.forward);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        //print(collision.gameObject.layer);
        //if (collision.gameObject.layer == 9)
        //{
        //print(LayerMask.NameToLayer("MouseRay"));
        //print(1 << LayerMask.NameToLayer("MouseRay") | 1 << LayerMask.NameToLayer("Cylinder"));  // 1을 이진법 상에서 LayerMask.NameToLayer("MouseRay") = 6 자리 만큼 밂 +
                                                                                                 // 1을 이진법 상에서 LayerMask.NameToLayer("Cylinder") = 9 자리 만큼 밂 = 576
        //}
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Cylinder"))
        //{
        //    print("Cylinder Collsion");
        //}

        //if (collision.collider.CompareTag("Cylinder"))
        //{
        //    print("Cylinder Collsion");
        //}

        //if (collision.collider.tag == "Cylinder")
        //{
        //    print("Cylinder collsion");
        //} 
    }

    void Update()
    {
        
    }
}
