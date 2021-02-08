using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;  //アニメーターを作成

    void Start()
    {
        animator = GetComponent<Animator>();    // アニメーターを取得
        agent = GetComponent<NavMeshAgent>(); 
        agent.destination = target.position; 
    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance); //Distanceを取得して距離に応じて動作する
    }
}
