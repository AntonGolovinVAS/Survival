using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace UnityStandardAssets.Characters.FirstPerson
{
    class MouseLook
    {
        /// <summary>
        /// Чувствительность X.
        /// </summary>
        public float XSensitivity = 2f;
        /// <summary>
        /// Чувствительность Y.
        /// </summary>
        public float YSensitivity = 2f;
        /// <summary>
        /// Минимальный X.
        /// </summary>
        public float MinimumX = -90F;
        /// <summary>
        /// Максимальный X.
        /// </summary>
        public float MaximumX = 90F;
        /// <summary>
        /// Плавно.
        /// </summary>
        public bool smooth;
        /// <summary>
        /// Время на плавно.
        /// </summary>
        public float smoothTime = 5f;
        /// <summary>
        /// зажим вертикального вращения.
        /// </summary>
        public bool clampVerticalRotation = true;


        /// <summary>
        /// Quaternion игрока.
        /// </summary>
        private Quaternion m_CharacterTargetRot;
        /// <summary>
        /// Quaternion главной камеры.
        /// </summary>
        private Quaternion m_CameraTargetRot;

        /// <summary>
        /// Инициализация Quaternion игрока и главной камеры.
        /// </summary>
        /// <param name="character">Transform игрока.</param>
        /// <param name="camera">Transform главной камеры.</param>
        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }

        /// <summary>
        /// Поворот взгляда.
        /// </summary>
        public void LookRotation(Transform character, Transform camera)
        {
            float yRotation = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float xRotation = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRotation, 0f);
            m_CameraTargetRot *= Quaternion.Euler(xRotation, 0f, 0f);

            if (clampVerticalRotation)
            {
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
            }
            if (smooth)
            {
                character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }

        }

        /// <summary>
        /// Зажим Вращение Вокруг Оси X
        /// </summary>
        /// <param name="quaternion">Quaternion камеры.</param>
        /// <returns></returns>
        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
    }
}
