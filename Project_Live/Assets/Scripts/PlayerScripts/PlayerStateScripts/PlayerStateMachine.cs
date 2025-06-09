using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//çÏê¨é“ÅFåKå¥

public class PlayerStateMachine : MonoBehaviour
{
    IPlayerState currentState;

    PlayerAnimationController anim;

    [SerializeField] MovePlayer movePlayer;
    [SerializeField] CloseAttack closeAttack;
    [SerializeField] ShotAttack shotAttack;
    [SerializeField] Dodge dodge;
    [SerializeField] GoodAction goodAction;

    public IPlayerState CurrentState { get { return currentState; } }    

    void Awake()
    {
        anim = GetComponent<PlayerAnimationController>();
        ChangeState(new IdleState(anim));
    }

    void OnEnable()
    {
        PlayerInputEvents.OnIdleInput += OnIdleInput;
        PlayerInputEvents.OnMoveInput += OnMoveInput;
        PlayerInputEvents.OnCloseAttackInput += OnCloseAttackInput;
        PlayerInputEvents.OnShotInput += OnShotInput;
        PlayerInputEvents.OnDodgeInput += OnDodgeInput;
        PlayerInputEvents.OnGoodAction1Input += OnGoodAction1Input;
        PlayerInputEvents.OnGoodAction2Input += OnGoodAction2Input;
        PlayerInputEvents.OnGoodAction3Input += OnGoodAction3Input;
        PlayerInputEvents.OnGoodAction4Input += OnGoodAction4Input;
    }

    void OnDisable()
    {
        PlayerInputEvents.OnIdleInput -= OnIdleInput;
        PlayerInputEvents.OnMoveInput -= OnMoveInput;
        PlayerInputEvents.OnCloseAttackInput -= OnCloseAttackInput;
        PlayerInputEvents.OnShotInput -= OnShotInput;
        PlayerInputEvents.OnDodgeInput -= OnDodgeInput;
        PlayerInputEvents.OnGoodAction1Input -= OnGoodAction1Input;
        PlayerInputEvents.OnGoodAction2Input -= OnGoodAction2Input;
        PlayerInputEvents.OnGoodAction3Input -= OnGoodAction3Input;
        PlayerInputEvents.OnGoodAction4Input -= OnGoodAction4Input;
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IPlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        //Debug.Log(currentState?.ToString());
    }

    void OnIdleInput()
    {
        if (!(currentState is IdleState)) ChangeState(new IdleState(anim));
    }

    void OnMoveInput()
    {
        if (currentState is IdleState && !(currentState is MoveState)) ChangeState(new MoveState(anim, movePlayer));
    }

    void OnCloseAttackInput()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is CloseAttackState))
        {
            ChangeState(new CloseAttackState(anim, closeAttack));
        }
    }

    void OnShotInput()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is ShotState))
        {
            ChangeState(new ShotState(anim, shotAttack));
        }
    }

    void OnDodgeInput()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is DodgeState))
        {
            //ChangeState(new DodgeState(anim, dodge));
        }
    }

    void OnGoodAction1Input()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is GoodAction1State))
        {
            //ChangeState(new GoodAction1State(anim, goodAction));
        }
    }

    void OnGoodAction2Input()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is GoodAction2State))
        {
            //ChangeState(new GoodAction2State(anim, goodAction));
        }
    }

    void OnGoodAction3Input()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is GoodAction3State))
        {
            //ChangeState(new GoodAction3State(anim, goodAction));
        }
    }

    void OnGoodAction4Input()
    {
        if ((currentState is IdleState || currentState is MoveState)
            && !(currentState is GoodAction4State))
        {
            //ChangeState(new GoodAction4State(anim, goodAction));
        }
    }
}
