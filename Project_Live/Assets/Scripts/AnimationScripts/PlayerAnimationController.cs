using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void PlayIdle() //�ҋ@�A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("TransitionNo", 0);
    }

    public void PlayMove() //�ړ��A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("TransitionNo", 1);
    }

    public void PlayCloseAttack1() //�ߐڍU��1�A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("CloseAttackNo", 0);
    }

    public void PlayCloseAttack2() //�ߐڍU��2�A�j���[�V�����̐ݒ�
    {
        animator.SetInteger("CloseAttackNo", 1);
    }

    public void PlayCloseAttack3() //�ߐڍU��3�A�j���[�V�����̐ݒ�
    {
        animator.SetInteger("CloseAttackNo", 2);
    }

    public void PlayCloseAttack4() //�ߐڍU��4�A�j���[�V�����̐ݒ�
    {
        animator.SetInteger("CloseAttackNo", 3);
    }

    public void PlayShotAttack() //�������U���A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetTrigger("Shot");
    }

    public void PlayDodge() //����A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetTrigger("Dodge");
    }

    public void PlayGoodAction1() //�����˃A�N�V����1�A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("GoodActionNo", 0);
    }

    public void PlayGoodAction2() //�����˃A�N�V����2�A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("GoodActionNo", 1);
    }

    public void PlayGoodAction3() //�����˃A�N�V����3�A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("GoodActionNo", 2);
    }

    public void PlayGoodAction4() //�����˃A�N�V����4�A�j���[�V�����̐ݒ�
    {
        ResetAllParameters();
        animator.SetInteger("GoodActionNo", 3);
    }

    public void ResetAllParameters() //�A�j���[�V�����̑J�ڗp�p�����[�^�̃��Z�b�g
    {
        animator.SetInteger("TransitionNo", -1);
        animator.SetInteger("CloseAttackNo", -1);
        animator.ResetTrigger("Shot");
        animator.ResetTrigger("Dodge");
        animator.SetInteger("GoodActionNo", -1);
    }
}
