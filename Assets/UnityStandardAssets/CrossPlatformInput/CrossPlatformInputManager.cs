using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
    /// <summary>
    /// Кросс-Платформенный Менеджер Ввода.
    /// </summary>
    public static class CrossPlatformInputManager
    {
        /// <summary>
        /// Способ Активного Ввода.
        /// </summary>
        public enum ActiveInputMethod
        {
            /// <summary>
            /// Оборудование.
            /// </summary>
            Hardware,
            /// <summary>
            /// Прикосновение.
            /// </summary>
            Touch
        }

        /// <summary>
        /// Активный вход.
        /// </summary>
        private static VirtualInput activeInput;
        /// <summary>
        /// Cенсорный ввод.
        /// </summary>
        private static VirtualInput s_TouchInput;
        /// <summary>
        /// Ввод оборудования.
        /// </summary>
        private static VirtualInput s_HardwareInput;

        /// <summary>
        /// Кросс-Платформенный Менеджер Ввода(Конструктор).
        /// </summary>
        static CrossPlatformInputManager()
        {
            s_TouchInput = new MobileInput();
            s_HardwareInput = new StandaloneInput();
#if MOBILE_INPUT
            activeInput = s_TouchInput;
#else
            activeInput = s_HardwareInput;
#endif
        }

        /// <summary>
        /// Переключить Активный Способ Ввода.
        /// </summary>
        /// <param name="activeInputMethod">Cпособ активного ввода.</param>
        public static void SwitchActiveInputMethod(ActiveInputMethod activeInputMethod)
        {
            switch (activeInputMethod)
            {
                case ActiveInputMethod.Hardware:
                    activeInput = s_HardwareInput;
                    break;

                case ActiveInputMethod.Touch:
                    activeInput = s_TouchInput;
                    break;
            }
        }

        /// <summary>
        /// Ось Существует.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <returns></returns>
        public static bool AxisExists(string name)
        {
            return activeInput.AxisExists(name);
        }

        /// <summary>
        /// Кнопка Существует.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public static bool ButtonExists(string name)
        {
            return activeInput.ButtonExists(name);
        }

        /// <summary>
        /// Зарегистрировать Виртуальную Ось.
        /// </summary>
        /// <param name="axis"></param>
        public static void RegisterVirtualAxis(VirtualAxis axis)
        {
            activeInput.RegisterVirtualAxis(axis);
        }

        /// <summary>
        /// Зарегистрировать Виртуальную Кнопку
        /// </summary>
        /// <param name="button">Название виртуальной кнопки.</param>
        public static void RegisterVirtualButton(VirtualButton button)
        {
            activeInput.RegisterVirtualButton(button);
        }

        /// <summary>
        /// Отменить Регистрацию Виртуальной Оси.
        /// </summary>
        /// <param name="name">Название виртуальной оси.</param>
        public static void UnRegisterVirtualAxis(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            activeInput.UnRegisterVirtualAxis(name);
        }

        /// <summary>
        /// Отменить Регистрацию Виртуальной Кнопки
        /// </summary>
        /// <param name="name">Название виртуальной кнопки.</param>
        public static void UnRegisterVirtualButton(string name)
        {
            activeInput.UnRegisterVirtualButton(name);
        }


        /// <summary>
        /// Возвращает ссылку на именованную виртуальную ось, если она существует в противном случае null.
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <returns></returns>
        public static VirtualAxis VirtualAxisReference(string name)
        {
            return activeInput.VirtualAxisReference(name);
        }


        /// <summary>
        /// Возвращает соответствующую ось платформы для данного имени
        /// </summary>
        /// <param name="name">Название оси.</param>
        /// <returns></returns>
        public static float GetAxis(string name)
        {
            return GetAxis(name, false);
        }


        public static float GetAxisRaw(string name)
        {
            return GetAxis(name, true);
        }


        // private function handles both types of axis (raw and not raw)
        private static float GetAxis(string name, bool raw)
        {
            return activeInput.GetAxis(name, raw);
        }


        /// <summary>
        /// Обработка нажатия кнопки 
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public static bool GetButton(string name)
        {
            return activeInput.GetButton(name);
        }

        /// <summary>
        /// Получить кнопку которую нажали.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public static bool GetButtonDown(string name)
        {
            return activeInput.GetButtonDown(name);
        }
        /// <summary>
        /// получить кнопку которую отпустили.
        /// </summary>
        /// <param name="name">Название кнопки.</param>
        /// <returns></returns>
        public static bool GetButtonUp(string name)
        {
            return activeInput.GetButtonUp(name);
        }


        public static void SetButtonDown(string name)
        {
            activeInput.SetButtonDown(name);
        }


        public static void SetButtonUp(string name)
        {
            activeInput.SetButtonUp(name);
        }


        public static void SetAxisPositive(string name)
        {
            activeInput.SetAxisPositive(name);
        }


        public static void SetAxisNegative(string name)
        {
            activeInput.SetAxisNegative(name);
        }


        public static void SetAxisZero(string name)
        {
            activeInput.SetAxisZero(name);
        }


        public static void SetAxis(string name, float value)
        {
            activeInput.SetAxis(name, value);
        }


        public static Vector3 mousePosition
        {
            get { return activeInput.MousePosition(); }
        }


        public static void SetVirtualMousePositionX(float f)
        {
            activeInput.SetVirtualMousePositionX(f);
        }


        public static void SetVirtualMousePositionY(float f)
        {
            activeInput.SetVirtualMousePositionY(f);
        }


        public static void SetVirtualMousePositionZ(float f)
        {
            activeInput.SetVirtualMousePositionZ(f);
        }

        /*
        
        Может быть сопоставлен с сенсорными джойстиками, наклоном, гироскопом и т. д. 
        В зависимости от желаемой реализации.
        Также могут быть реализованы другие устройства ввода-kinect, электронные датчики и т. д

        */
        /// <summary>
        /// Класс виртуальных осей и кнопок-применяется к мобильному входу.
        /// </summary>
        public class VirtualAxis
        {
            /// <summary>
            /// Наименование.
            /// </summary>
            public string name { get; private set; }
            /// <summary>
            /// Значение.
            /// </summary>
            private float m_Value;
            /// <summary>
            /// Cопоставление с диспетчером ввода.
            /// </summary>
            public bool matchWithInputManager
            {
                get;
                private set;
            }

            public VirtualAxis(string name)
                : this(name, true)
            {
            }


            public VirtualAxis(string name, bool matchToInputSettings)
            {
                this.name = name;
                matchWithInputManager = matchToInputSettings;
            }

            /// <summary>
            /// Удаляет оси из системы ввода cross platform.
            /// </summary>
            public void Remove()
            {
                UnRegisterVirtualAxis(name);
            }


            /// <summary>
            /// Контроллер gameobject (e g. виртуальный thumbstick) должен обновить этот класс.
            /// </summary>
            /// <param name="value"></param>
            public void Update(float value)
            {
                m_Value = value;
            }

            /// <summary>
            /// Получить Значение.
            /// </summary>
            public float GetValue
            {
                get { return m_Value; }
            }

            /// <summary>
            /// Получить Значение.
            /// </summary>
            public float GetValueRaw
            {
                get { return m_Value; }
            }
        }

        /// <summary>
        /// на объект управления (например. виртуальная кнопка GUI) должна вызывать функцию 'pressed' этого класса.
        /// Другие объекты могут после этого прочитать Get/ Down / Up состояние этой кнопки.
        /// </summary>
        public class VirtualButton
        {
            /// <summary>
            /// Название кнопки.
            /// </summary>
            public string name {
                get;
                private set;
            }
            /// <summary>
            /// Cопоставление с диспетчером ввода.
            /// </summary>
            public bool matchWithInputManager {
                get;
                private set;
            }

            /// <summary>
            /// Последний нажатый кадр.
            /// </summary>
            private int m_LastPressedFrame = -5;
            /// <summary>
            /// Выполненный кадр.
            /// </summary>
            private int m_ReleasedFrame = -5;
            /// <summary>
            /// Нажатый.
            /// </summary>
            private bool m_Pressed;

            /// <summary>
            /// Виртуальная кнопка.
            /// </summary>
            /// <param name="name">Название кнопки.</param>
            public VirtualButton(string name): this(name, true)
            {
            }

            /// <summary>
            /// Виртуальная кнопка.
            /// </summary>
            /// <param name="name">Название кнопки.</param>
            /// <param name="matchToInputSettings">Соответствие входным настройкам.</param>
            public VirtualButton(string name, bool matchToInputSettings)
            {
                this.name = name;
                matchWithInputManager = matchToInputSettings;
            }


            /// <summary>
            /// Контроллер gameobject должен вызывать эту функцию при нажатии кнопки.
            /// </summary>
            public void Pressed()
            {
                if (m_Pressed)
                {
                    return;
                }
                m_Pressed = true;
                m_LastPressedFrame = Time.frameCount;
            }


            /// <summary>
            /// Контроллер gameobject должен вызывать эту функцию при отпускании кнопки.
            /// </summary>
            public void Released()
            {
                m_Pressed = false;
                m_ReleasedFrame = Time.frameCount;
            }


            /// <summary>
            /// Этот объект контроллер должен вызвать удалить, когда кнопка будет уничтожен или отключен.
            /// </summary>
            public void Remove()
            {
                UnRegisterVirtualButton(name);
            }


            /// <summary>
            /// Это состояние кнопки которую можно прочитать через систему входного сигнала перекрестной платформы.
            /// </summary>
            public bool GetButton
            {
                get { return m_Pressed; }
            }

            /// <summary>
            /// Нажать кнопку.
            /// </summary>
            public bool GetButtonDown
            {
                get
                {
                    return m_LastPressedFrame - Time.frameCount == -1;
                }
            }

            /// <summary>
            /// Отпустить кнопку.
            /// </summary>
            public bool GetButtonUp
            {
                get
                {
                    return (m_ReleasedFrame == Time.frameCount - 1);
                }
            }
        }
    }
}
