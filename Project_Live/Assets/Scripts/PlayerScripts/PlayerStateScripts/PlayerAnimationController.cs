using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//çÏê¨é“ÅFåKå¥

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    Animator animator;

    void Awake()
    {
        animator = playerAnimator.GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        ResetAllParameters();
        animator.SetInteger("TransitionNo", 0);
    }

    public void PlayMove()
    {
        ResetAllParameters();
        animator.SetInteger("TransitionNo", 1);
    }

    public void PlayCloseAttack1()
    {
        ResetAllParameters();
        animator.SetInteger("CloseAttackNo", 0);
    }

    public void PlayCloseAttack2()
    {
        //ResetAllParameters();
        animator.SetInteger("CloseAttackNo", 1);
    }

    public void PlayCloseAttack3()
    {
        //ResetAllParameters();
        animator.SetInteger("CloseAttackNo", 2);
    }

    public void PlayCloseAttack4()
    {
        //ResetAllParameters();
        animator.SetInteger("CloseAttackNo", 3);
    }

    public void PlayShotAttack()
    {
        animator.SetTrigger("Shot");
    }

    public void PlayDodge()
    {
        animator.SetTrigger("Dodge");
    }

    public void PlayGoodAction1()
    {
        animator.SetTrigger("GoodAction1");
    }

    public void PlayGoodAction2()
    {
        animator.SetTrigger("GoodAction2");
    }

    public void PlayGoodAction3()
    {
        animator.SetTrigger("GoodAction3");
    }

    public void PlayGoodAction4()
    {
        animator.SetTrigger("GoodAction4");
    }

    public void ResetAllParameters()
    {
        animator.SetInteger("TransitionNo", -1);
        animator.SetInteger("CloseAttackNo", -1);
    }
}
