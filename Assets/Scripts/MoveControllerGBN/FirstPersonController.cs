//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FirstPersonController : MonoBehaviour
//{
//    #region Ссылки на компоненты.
//    private CharacterController m_CharacterController;
//    private AudioSource m_AudioSource;// the sound played when character touches back on ground.
//    #endregion

//    #region
//    private Camera m_Camera;
//    private Vector3 m_OriginalCameraPosition;
//    #endregion

//    #region Audio
//    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
//    [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
//    [SerializeField] private AudioClip m_LandSound;
//    #endregion

//    private bool m_Jump;
//    private bool m_Dive;
//    public bool isActive;
//    void Start()
//    {
//        isActive = true;
//        m_AudioSource = GetComponent<AudioSource>();
//        m_Camera = Camera.main;
//    }

//    void Update()
//    {
//        if (isActive)
//        {
//            if (!m_Jump)
//            {
                
//            }
//        }
//    }

//    public void StopController()
//    {
//        isActive = false;
//    }

//    private void PlayLandingSound()
//    {
//        m_AudioSource.clip = m_LandSound;
//        m_AudioSource.Play();
//    }
//    private void FixedUpdate()
//    {
//    }

//    private void PlayJumpSound()
//    {
//    }

//    private void ProgressStepCycle(float speed)
//    {
//    }

//    private void PlayFootStepAudio()
//    {
//    }

//    private void UpdateCameraPosition(float speed)
//    {
//    }

//    //private void GetInput(out float speed)
//    //{
//    //}

//    private void RotateView()
//    {
//    }
//    private void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//    }
//}