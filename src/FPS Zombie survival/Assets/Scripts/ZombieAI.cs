using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    public enum AIState { idle, chasing, attacking, roaming};
    public AIState aIState = AIState.idle;
    public Animator animator;
    [SerializeField] public float cooldown = 20f;
    private bool playerDead = false;
    [SerializeField] private float noticeDistance = 8f;
    private float followDistance;
    private NavMeshAgent navAgent;
    private Transform playerTrans;
    private GameObject player;
    private ZombieManager zombieManager;
    [SerializeField] private float attackDamage = 10f;
 
    private float lastAttacked = -9999f;


    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        zombieManager = GetComponent<ZombieManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        followDistance = noticeDistance + 10f;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTrans.position, transform.position);
        switch (aIState){
            case AIState.idle:
            StayIdle(distance);
                break;
            case AIState.chasing:
            Chasing(distance);
                break;
            case AIState.attacking:
            Attacking(distance);
                break;
            case AIState.roaming:
            // Add when extra
                break;
            default:
                break;
        }
    }

    private void StayIdle(float distance){
        if(distance < noticeDistance && !PlayerManagement.singleton.isDead){
            aIState = AIState.chasing;
            animator.SetBool("Chasing", true);
        }
        else{
            DisableZombie();
        }
        navAgent.SetDestination(transform.position);
    }
    private void Chasing(float distance){
        if(distance > followDistance){
            aIState = AIState.idle;
            animator.SetBool("Chasing", false);
        }
        else{
            navAgent.SetDestination(playerTrans.position);
            if(distance < 2f){
                if(!playerDead){
                    aIState = AIState.attacking;
                    animator.SetBool("Attacking", true); 
                }
                else{
                    DisableZombie();
                }
            }
        }
    }
    private void Attacking(float distance){
        if(distance > 2f){
            aIState = AIState.chasing;
            animator.SetBool("Attacking", false);
        }
        else{
            navAgent.SetDestination(transform.position);
            if(!PlayerManagement.singleton.isDead){
                if(Time.time > lastAttacked + cooldown){
                    PlayerManagement.singleton.TakeDamage(attackDamage);
                    lastAttacked = Time.time;
                }
            }
            else{
                DisableZombie();
            }
        }
    }

    private void DisableZombie(){
        animator.SetBool("Attacking", false);
        animator.SetBool("Chasing", false);
    }
}
