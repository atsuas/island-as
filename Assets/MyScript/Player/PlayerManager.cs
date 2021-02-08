using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float x;
    float z;
    public float moveSpeed;
    public Collider punchCollider; //設定する
    public Collider kickCollider;

    Rigidbody rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideColliderPunch();   //最初は隠しておく
        HideColliderKick();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        //攻撃
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Kick");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("Brooklyn");
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.position + new Vector3(x, 0, z) * moveSpeed;
        transform.LookAt(direction);

        rb.velocity = new Vector3(x, 0, z) * moveSpeed;
        animator.SetFloat("Speed", rb.velocity.magnitude);
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

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            animator.SetTrigger("Hurt");
        }
    }
}
