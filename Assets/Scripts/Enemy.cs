using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rbody;
    public float speed;
    public float moveRangeDistance;
    public Vector4 moveRange; // -x, x, -z, z
    public Vector3 moveTarget;
    public bool isDie;
    public float dieForce;
    GameManager gameManager;
    void Start()
    {
        Vector3 pos = transform.position;
        moveRange = new Vector4(pos.x - moveRangeDistance, pos.x + moveRangeDistance, pos.z - moveRangeDistance, pos.x + moveRangeDistance);
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(MoveCo());
    }

    IEnumerator MoveCo()
    {
        while (true)
        {
            //yield return null; // << 한 프레임 대기
            //yield return new WaitForSeconds(1); // << 1초 대기

            moveTarget.x = Random.Range(moveRange.x, moveRange.y);
            moveTarget.z = Random.Range(moveRange.z, moveRange.w);

            while (true)
            {
                yield return new WaitForFixedUpdate();
                rbody.MovePosition(Vector3.MoveTowards(rbody.position, moveTarget, speed));
                if (Vector3.Distance(rbody.position, moveTarget) < 0.1)
                {
                    break;  // << while을 빠져나감
                }
                if (isDie)
                {
                    yield break;    // << Corutine을 종료함
                }
            }

            yield return new WaitForSeconds(2);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isDie && collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            isDie = true;
            StartCoroutine(DieCo(collision));

        }
        else if (!isDie && collision.gameObject.name.Contains("Wall"))
        {
            //StopCoroutine(MoveCo());
            //StartCoroutine(MoveCo());
            moveTarget.x = Random.Range(moveRange.x, moveRange.y);
            moveTarget.z = Random.Range(moveRange.z, moveRange.w);

        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (!isDie && collision.gameObject.name.Contains("Wall"))
        {
            //StopCoroutine(MoveCo());
            //StartCoroutine(MoveCo());
            moveTarget.x = Random.Range(moveRange.x, moveRange.y);
            moveTarget.z = Random.Range(moveRange.z, moveRange.w);

        }
    }

    IEnumerator DieCo(Collision collision)
    {
        print("Death");
        Rigidbody bulletRbody = collision.collider.GetComponent<Rigidbody>();
        Vector3 bulletVellocity = bulletRbody.velocity;
        bulletVellocity.y = -1;
        rbody.AddForce(bulletRbody.velocity * dieForce);
        rbody.constraints = RigidbodyConstraints.None;  // << Rigidbody의 이동, 회전 제한을 해제
        gameManager.HitEnemy();

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
