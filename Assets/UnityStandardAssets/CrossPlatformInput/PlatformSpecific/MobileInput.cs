using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
    /// <summary>
    /// MobileInput.
    /// </summary>
    public class MobileInput : VirtualInput
    {
        /// <summary>
        /// Добавить кнопку.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        private void AddButton(string name)
        {
            // Мы еще не зарегистрировали эту кнопку, поэтому добавьте ее в конструктор.
            CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
        }

        /// <summary>
        /// Добавить Оси.
        /// </summary>
        /// <param name="name">Название оси.</param>
        private void AddAxes(string name)
        {
            // Мы еще не зарегистрировали эту кнопку, поэтому добавьте ее в конструктор.
            CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
        }

        /// <summary>
        /// Получить Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <param name="raw">Необработанный.</param>
        /// <returns></returns>
        public override float GetAxis(string name, bool raw)
        {
            if (!m_VirtualAxes.ContainsKey(name))
            {
                AddAxes(name);
            }
            return m_VirtualAxes[name].GetValue;
        }

        /// <summary>
        /// Установить кнопку вниз.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        public override void SetButtonDown(string name)
        {
            if (!m_VirtualButtons.ContainsKey(name))
            {
                AddButton(name);
            }
            m_VirtualButtons[name].Pressed();
        }

        /// <summary>
        /// Установить кнопку вверх.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        public override void SetButtonUp(string name)
        {
            if (!m_VirtualButtons.ContainsKey(name))
            {
                AddButton(name);
            }
            m_VirtualButtons[name].Released();
        }

        /// <summary>
        /// Установить Положительную Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        public override void SetAxisPositive(string name)
        {
            if (!m_VirtualAxes.ContainsKey(name))
            {
                AddAxes(name);
            }
            m_VirtualAxes[name].Update(1f);
        }

        /// <summary>
        /// Установить Отрицательную Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        public override void SetAxisNegative(string name)
        {
            if (!m_VirtualAxes.ContainsKey(name))
            {
                AddAxes(name);
            }
            m_VirtualAxes[name].Update(-1f);
        }

        /// <summary>
        /// Установить Нулевую Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        public override void SetAxisZero(string name)
        {
            if (!m_VirtualAxes.ContainsKey(name))
            {
                AddAxes(name);
            }
            m_VirtualAxes[name].Update(0f);
        }

        /// <summary>
        /// Установить Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <param name="value">Значение оси.</param>
        public override void SetAxis(string name, float value)
        {
            if (!m_VirtualAxes.ContainsKey(name))
            {
                AddAxes(name);
            }
            m_VirtualAxes[name].Update(value);
        }

        /// <summary>
        /// Сделать Кнопку Вниз.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public override bool GetButtonDown(string name)
        {
            if (m_VirtualButtons.ContainsKey(name))
            {
                return m_VirtualButtons[name].GetButtonDown;
            }

            AddButton(name);
            return m_VirtualButtons[name].GetButtonDown;
        }

        /// <summary>
        /// Сделать Кнопку Вверх.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public override bool GetButtonUp(string name)
        {
            if (m_VirtualButtons.ContainsKey(name))
            {
                return m_VirtualButtons[name].GetButtonUp;
            }

            AddButton(name);
            return m_VirtualButtons[name].GetButtonUp;
        }

        /// <summary>
        /// Получить кнопку.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public override bool GetButton(string name)
        {
            if (m_VirtualButtons.ContainsKey(name))
            {
                return m_VirtualButtons[name].GetButton;
            }

            AddButton(name);
            return m_VirtualButtons[name].GetButton;
        }

        /// <summary>
        /// Положение Мыши.
        /// </summary>
        /// <returns></returns>
        public override Vector3 MousePosition()
        {
            return virtualMousePosition;
        }
    }
}
