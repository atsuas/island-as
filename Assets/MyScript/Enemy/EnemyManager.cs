using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //agentを設定
        agent.destination = target.position; //agentの場所はどこですか？ ＝ ターゲットの場所です
    }

    void Update()
    {
        agent.destination = target.position;
    }
}
