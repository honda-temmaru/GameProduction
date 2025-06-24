using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class MovePlayer : MonoBehaviour
{
    [Header("�������I�u�W�F�N�g")]
    [SerializeField] Transform target;
    [Header("�ړ��X�s�[�h�̔{��")]
    [SerializeField] float speed = 1f;
    [Header("��]�X�s�[�h�̔{��")]
    [SerializeField] float rotationSpeed = 1f;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] PlayerStatus status;
    [SerializeField] CameraDirectionCalculator cameraDirectionCalculator;
    [SerializeField] Dodge dodge;

    Vector3 move; //���͒l�擾�p�ϐ�
    Vector3 prev_Move = Vector3.zero; //�O�t���[���̈ړ��l�ۑ��p�ϐ�
    Vector3 prev_Position; //�O�t���[���̈ʒu�ۑ��p�ϐ�
    Vector3 moveDirection; //�ړ������p�̕ϐ�

    float moveSpeedMultiplier = 1f; //�ړ��ʐ����p�̕ϐ�
    float rotateSpeedMultiplier = 1f; //��]�ʐ����p�̕ϐ�

    public Vector3 Move { get { return move; } }
    public Vector3 Prev_Move { get {  return prev_Move; } }
    public Vector3 Position { get { return target.position; } }
    public Vector3 Prev_Position { get { return prev_Position; } }

    public float MoveSpeedMultiplier { get { return moveSpeedMultiplier; } set { moveSpeedMultiplier = value; } }
    public float RotationSpeedMultiplier { get { return rotateSpeedMultiplier; } set {  rotateSpeedMultiplier = value; } }

    public void MoveProcess() //�ړ���Ԃ̈ړ�����
    {
        prev_Move = move; //�ړ��̒l��ۑ�

        if (move.magnitude > 0.1f) //�ړ��̓��͂���������
        {
            CalculateMoveDirection();
            RotateTransform();
            MoveTransform();
        }

        else if (move == prev_Move)
        {
            PlayerActionEvents.IdleEvent();
        }

        prev_Position = target.position; //���ݒn�_��ۑ�
    }

    public void MoveProcess_AnyAttackState() //�U����Ԃ̈ړ�����
    {
        if (move.magnitude > 0.1f) //�ړ��̓��͂���������
        {
            CalculateMoveDirection();
            RotateTransform();
            MoveTransform();
        }
    }

    void CalculateMoveDirection() //�ړ������̌v�Z
    {
        moveDirection = cameraDirectionCalculator.CamForWard * move.z + cameraDirectionCalculator.CamRight * move.x; //�ړ������̎Z�o
    }

    void MoveTransform() //�ړ�����
    {    
        target.transform.position += moveDirection * speed * moveSpeedMultiplier * status.Agility * Time.deltaTime;
    }

    void RotateTransform() //��]����
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        //��]���x�ɐ�����������
        target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, targetRotation, rotationSpeed * rotateSpeedMultiplier * status.Agility * Time.deltaTime);
    }

    public void GetMoveVector(Vector3 getVec)
    {
        move = new Vector3(getVec.x, 0, getVec.z); //���͒l�̎擾
    }
}
