using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    /// <summary>
    /// Виртуальный Ввод
    /// </summary>
    public abstract class VirtualInput
    {
        /// <summary>
        /// Положение виртуальной мыши.
        /// </summary>
        public Vector3 virtualMousePosition
        {
            get;
            private set;
        }

        /// <summary>
        /// Словарь для хранения имени, относящегося к виртуальным осям.
        /// </summary>
        protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();
        /// <summary>
        /// Словарь для хранения имени, относящегося к виртуальным осям
        /// </summary>
        protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();
        /// <summary>
        ///  Cписок имен осей и кнопок, помеченных для использования виртуальной оси или кнопки.
        /// </summary>
        protected List<string> m_AlwaysUseVirtual = new List<string>();
       

        /// <summary>
        /// Ось Существует.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <returns></returns>
        public bool AxisExists(string name)
        {
            return m_VirtualAxes.ContainsKey(name);
        }

        /// <summary>
        /// Кнопка существует.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public bool ButtonExists(string name)
        {
            return m_VirtualButtons.ContainsKey(name);
        }

        /// <summary>
        /// Зарегистрировать Виртуальную Ось.
        /// </summary>
        /// <param name="axis">Виртуальная ось.</param>
        public void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
        {
            // проверьте, есть ли у нас ось с этим именем и журналом и ошибка, если мы это сделаем
            if (m_VirtualAxes.ContainsKey(axis.name))
            {
                Debug.LogError("There is already a virtual axis named " + axis.name + " registered.");
            }
            else
            {
                // добавить новые axes
                m_VirtualAxes.Add(axis.name, axis);

                // если мы не хотим совпадать с настройкой input manager, вернитесь к использованию виртуального

                if (!axis.matchWithInputManager)
                {
                    m_AlwaysUseVirtual.Add(axis.name);
                }
            }
        }

        /// <summary>
        /// Зарегистрирвать виртуальную кнопку.
        /// </summary>
        /// <param name="button">Виртуальная кнопка.</param>
        public void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
        {
            // проверьте, есть ли уже кнопка с этим именем и зарегистрируйте ошибку, если мы это сделаем
            if (m_VirtualButtons.ContainsKey(button.name))
            {
                Debug.LogError("There is already a virtual button named " + button.name + " registered.");
            }
            else
            {
                // добавить новые buttons
                m_VirtualButtons.Add(button.name, button);

                // если мы не хотим соответствовать менеджеру ввода, всегда используйте виртуальную ось
                if (!button.matchWithInputManager)
                {
                    m_AlwaysUseVirtual.Add(button.name);
                }
            }
        }

        /// <summary>
        /// Отменить Регистрацию Виртуальной Оси.
        /// </summary>
        /// <param name="name">Название виртуальной оси.</param>
        public void UnRegisterVirtualAxis(string name)
        {
            // если у нас есть ось с этим именем, удалите ее из нашего словаря зарегистрированных осей
            if (m_VirtualAxes.ContainsKey(name))
            {
                m_VirtualAxes.Remove(name);
            }
        }

        /// <summary>
        /// Отменить Регистрацию Виртуальной Кнопки.
        /// </summary>
        /// <param name="name">Виртуальная кнопка.</param>
        public void UnRegisterVirtualButton(string name)
        {
            // если у нас есть кнопка с этим именем, удалите ее из нашего словаря зарегистрированных кнопок
            if (m_VirtualButtons.ContainsKey(name))
            {
                m_VirtualButtons.Remove(name);
            }
        }


        /// <summary>
        /// Возвращает ссылку на именованную виртуальную ось, если она существует в противном случае null
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <returns></returns>
        public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
        {
            return m_VirtualAxes.ContainsKey(name) ? m_VirtualAxes[name] : null;
        }

        /// <summary>
        /// Установить Виртуальных Позицию Мыши X.
        /// </summary>
        /// <param name="f">Виртуальная позиция мыши X.</param>
        public void SetVirtualMousePositionX(float f)
        {
            virtualMousePosition = new Vector3(f, virtualMousePosition.y, virtualMousePosition.z);
        }

        /// <summary>
        /// Установка Положения Виртуальной Мыши Y.
        /// </summary>
        /// <param name="f">Виртуальное положение мыши Y.</param>
        public void SetVirtualMousePositionY(float f)
        {
            virtualMousePosition = new Vector3(virtualMousePosition.x, f, virtualMousePosition.z);
        }

        /// <summary>
        /// Установка Положения Виртуальной Мыши Z.
        /// </summary>
        /// <param name="f">Виртуальное положение мыши Z.</param>
        public void SetVirtualMousePositionZ(float f)
        {
            virtualMousePosition = new Vector3(virtualMousePosition.x, virtualMousePosition.y, f);
        }

        /// <summary>
        /// Получить Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <param name="raw">Необработанный.</param>
        /// <returns></returns>
        public abstract float GetAxis(string name, bool raw);
        /// <summary>
        /// Получить кнопку.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public abstract bool GetButton(string name);
        /// <summary>
        /// Сделать Кнопку Вниз.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public abstract bool GetButtonDown(string name);
        /// <summary>
        /// Сделать Кнопку Вверх.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public abstract bool GetButtonUp(string name);
        /// <summary>
        /// Установить кнопку вниз.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        public abstract void SetButtonDown(string name);
        /// <summary>
        /// Установить кнопку вверх.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        public abstract void SetButtonUp(string name);
        /// <summary>
        /// Установить Положительную Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        public abstract void SetAxisPositive(string name);
        /// <summary>
        /// Установить Отрицательную Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        public abstract void SetAxisNegative(string name);
        /// <summary>
        /// Установить Нулевую Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        public abstract void SetAxisZero(string name);
        /// <summary>
        /// Установить Ось.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <param name="value">Значение оси.</param>
        public abstract void SetAxis(string name, float value);
        /// <summary>
        /// Положение Мыши.
        /// </summary>
        /// <returns></returns>
        public abstract Vector3 MousePosition();
    }

}

