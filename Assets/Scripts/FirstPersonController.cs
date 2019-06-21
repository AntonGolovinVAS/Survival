using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class FirstPersonController : MonoBehaviour {

    #region Private
    [SerializeField] private bool m_IsWalking;
    [SerializeField] private float m_WalkSpeed;
    [SerializeField] private float m_RunSpeed;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] float m_JumpSpeed;
    [SerializeField] float m_DriveSpeed;
    float m_DriveSpeedCurrent;
    [SerializeField] private float m_WaterDampingMultiplier;
    [SerializeField] private float m_StickToGroundForce;
    [SerializeField] private float m_GravityMultiplier;
    [SerializeField] private MouseLook m_MouseLook;
    [SerializeField] private bool m_UseFovKick;
    [SerializeField] private FOVKick m_FovKick = new FOVKick();
    [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
    [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.

    private Camera m_Camera;
    private bool m_Jump;
    private bool m_Dive;
    private float m_YRotation;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private bool m_PreviouslyDived;
    private Vector3 m_OriginalCameraPosition;
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_Jumping;
    //        private bool m_Diving;
    private AudioSource m_AudioSource;

    private SwimmingController m_SwimmingController;
    //		[SerializeField] private Transform personFace;

    public bool isActive;
    public void StopController()
    {
        isActive = false;
    }

    //public Vector3 groundPosition;

    // Use this for initialization
    private Camera m_Camera;
    private Vector3 m_OriginalCameraPosition;
    #endregion
    [SerializeField] private CharacterController m_CharacterController;

    private bool m_Jump;

    public bool isActive;
 

    void Start ()
    {
        
    }


    void Update ()
    {
        if (isActive)
        {
            if (!m_Jump)
            {
               
            }
        }
	}

    public void StopController()
    {

    }

    void PlayLandingSound()
    {

    }

    void FixedUpdate()
    {

    }

    void PlayJumpSound()
    {

    }

    void ProgressStepCycle()
    {

    }

    void PlayFootStepAudio()
    {

    }

    void UpdateCameraPosition()
    {

    }

    void GetInput()
    {

    }

    /// <summary>
    /// Поворот вида.
    /// </summary>
    void RotateView()
    {

    }

    void OnControllerColliderHit()
    {

    }
}
