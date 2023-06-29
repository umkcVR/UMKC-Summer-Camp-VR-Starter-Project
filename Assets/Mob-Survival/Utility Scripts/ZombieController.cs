using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed = 1.0f, attackRange = 0.5f;
    public GameObject target;
    public bool isAlive = true;
    public Animator animator;

    public void Update()
    {
        if(isAlive)
        {
            if(Vector3.Distance(transform.position, target.transform.position) < attackRange)
            {
                Attack();
                animator.SetFloat("speed", 0f);
                animator.SetBool("attack", true);

            }
            else
            {
                animator.SetFloat("speed", 1.0f);
                animator.SetBool("attack", false);
                MoveTowardsTarget();
            }
        }
        else
        {
            animator.SetFloat("speed", 0f);
            animator.SetBool("attack", false);
            animator.SetBool("death", true);

        }
    }

    void MoveTowardsTarget()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = target.transform.position;
        endPosition.y = transform.position.y;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(startPosition, endPosition, step);
    }
    void Attack()
    {

    }
}
