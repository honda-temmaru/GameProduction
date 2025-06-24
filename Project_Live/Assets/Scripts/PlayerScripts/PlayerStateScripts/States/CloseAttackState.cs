using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class CloseAttackState : IPlayerState
{
    PlayerAnimationController anim;
    MovePlayer movePlayer;
    CloseAttack closeAttack;

    bool playedCurrentAnim = false;
    int lastAttackIndex = -1;

    public CloseAttackState(PlayerAnimationController anim, MovePlayer movePlayer, CloseAttack closeAttack)
    {
        this.anim = anim;
        this.movePlayer = movePlayer;
        this.closeAttack = closeAttack;
    }

    public void Enter()
    {
        //Debug.Log("�ߐڍU����ԂɈڍs");
    }

    public void Update()
    {
        closeAttack.CloseAttackProcess(); //�ߐڍU������
        movePlayer.MoveProcess_AnyAttackState(); //�ړ�����

        if (closeAttack.CurrentAttackState == CloseAttack.AttackState.Windup)
        {
            playedCurrentAnim = false;
            AnimationProcess(); //�A�j���[�V�����Đ�����
        }


        if (closeAttack.CurrentAttackState == CloseAttack.AttackState.None)
        {
            playedCurrentAnim = false;
            lastAttackIndex = -1;
            //Debug.Log("Reset");
        }
    }

    public void Exit()
    {
        //Debug.Log("�ߐڍU����Ԃ��I��");
    }

    void AnimationProcess()
    {
        if (lastAttackIndex == closeAttack.CurrentComboIndex) return;

        if (closeAttack.CurrentAttackState == CloseAttack.AttackState.Windup && !playedCurrentAnim)
        {
            switch (closeAttack.CurrentComboIndex)
            {
                case 0:
                    anim.PlayCloseAttack1(); break;

                case 1:
                    anim.PlayCloseAttack2(); break;
                
                case 2:
                    anim.PlayCloseAttack3(); break;
                
                case 3:
                    anim.PlayCloseAttack4(); break;
            }

            playedCurrentAnim = true;
            lastAttackIndex = closeAttack.CurrentComboIndex;
        }
    }
}
