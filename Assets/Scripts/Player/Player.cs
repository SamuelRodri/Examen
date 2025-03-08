using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnDie;
    public event Action<float> OnHit;

    [SerializeField] private float movementVelocity;
    [SerializeField] private float life;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (h != 0)
        {
            transform.Translate(transform.right * h * movementVelocity * Time.deltaTime);
            animator.SetFloat("Horizontal", h);
        }
        else if (v != 0)
        {
            transform.Translate(transform.up * v * movementVelocity * Time.deltaTime);
            animator.SetFloat("Vertical", v);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetBool("Idle", true);
        }
    }

    public void Hit(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            OnDie?.Invoke();
        }

        OnHit?.Invoke(life);
    }
}
