using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    #region Основные параметры.
    /// <summary>
    /// Скорость двжения.
    /// </summary>
    public float player_SpeedMove;
    /// <summary>
    /// Сила прыжка.
    /// </summary>
    public float player_JumpPower;
    #endregion
    #region Параметры геймплея для персонажа.
    /// <summary>
    /// Грвитация персонажа.
    /// </summary>
    float player_GravityForce;
    /// <summary>
    /// Наповление движения персонажа.
    /// </summary>
    Vector3 player_MoveVector;
    #endregion
    #region Ссылки на компоненты.
    CharacterController characterController;
    Animator animator;
    MobileController mobileController;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mobileController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    void Update()
    {
        PlayerMove();
        GamingGravity();
    }

    /// <summary>
    /// Метод перемещения персонажа.
    /// </summary>
    private void PlayerMove()
    {
        if (characterController.isGrounded)
        {
            player_MoveVector = Vector3.zero;
            player_MoveVector.x = mobileController.Horizontal() * player_SpeedMove;
            player_MoveVector.z = mobileController.Vertical() * player_SpeedMove;
            if (Vector3.Angle(transform.forward, player_MoveVector) > 1f || Vector3.Angle(transform.forward, player_MoveVector) == 0f)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, player_MoveVector, player_SpeedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        }
        //player_RigidBody.AddForce(((transform.right * mobileController.Horizontal() + (transform.forward * mobileController.Vertical())) * player_SpeedMove / Time.deltaTime));
        player_MoveVector.y = player_GravityForce;

        characterController.Move(player_MoveVector * Time.deltaTime);
    }

    /// <summary>
    /// Метод гравитации.
    /// </summary>
    private void GamingGravity()
    {
        if (!characterController.isGrounded)
        {
            player_GravityForce -= 200f * Time.deltaTime;
        }
        else
        {
            player_GravityForce = -1f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            player_GravityForce = player_JumpPower;
        }
    }
}