using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    public Collider punchCollider;
    public Collider kickCollider;

    void Start()
    {
        animator = GetComponent<Animator>();  
        agent = GetComponent<NavMeshAgent>(); 
        agent.destination = target.position;
        HideColliderPunch();
        HideColliderKick();
    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance); 
    }

    //攻撃の判定
    public void HideColliderPunch()
    {
        punchCollider.enabled = false; //無効にする
    }
    public void ShowColliderPunch()
    {
        punchCollider.enabled = true;  //有効にする
    }
    public void HideColliderKick()
    {
        kickCollider.enabled = false; //無効にする
    }
    public void ShowColliderKick()
    {
        kickCollider.enabled = true;  //有効にする
    }

    private void OnTriggerEnter(Collider other)　// 当たり判定
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            //ダメージを与えるものにぶつかったら
            animator.SetTrigger("Hurt");
        }
    }
}
