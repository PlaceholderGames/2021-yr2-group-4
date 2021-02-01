using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemyScript : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        animator.SetBool("IsWalking", false);
        //If player in radius, chase 
        if (distance <= lookRadius)
        {
            //Chase function
            agent.SetDestination(target.position);
            //If enemy is chasing player change animation from idle to walk
            animator.SetBool("IsWalking", true);
            //Look at player when close
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                animator.SetBool("Attack", true);
                Invoke("Restart", 2); //2 is the time
                //Restart();
            }
        }
        
    }

    //Look at player when close function
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
