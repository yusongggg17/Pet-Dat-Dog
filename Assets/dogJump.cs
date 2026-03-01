using System;
using UnityEditor.Animations;
using UnityEngine;

public class dogJump : MonoBehaviour
{
    public Animator animator;
    public bool playJump;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playJump)
        {
            animator.SetTrigger("Jump");
            playJump = false; // prevent constant triggering
        }
    }

    public void playJumpAnim()
    {
        animator.SetTrigger("Jump");
        print("dogjumped");
    }
}
