using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float limitSpeed;

    private float movementSpeed;
    private GameObject playerBase;

    private Vector3 direction;

    private Animator animator;

    public void Initialize(float speed)
    {
        movementSpeed = speed;

        if(movementSpeed > limitSpeed)
        {
            movementSpeed = limitSpeed;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerBase = GameObject.FindGameObjectWithTag("PlayerBase");
        direction = playerBase.transform.position - transform.position;

        if (direction.x < 0)
        {
            animator.SetBool("WalkRight", true);
        }
        else if (direction.x > 0)
        {
            animator.SetBool("WalkLeft", true);
        }
    }

    void Update()
    {
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBase"))
        {
            collision.GetComponent<PlayerBase>().Attack(damage);
        }
    }
}
