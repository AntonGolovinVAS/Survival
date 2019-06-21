using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVKick
{
    /// <summary>
    ///  дополнительная настройка камеры, если ноль будет использоваться основная камера
    /// </summary>
    public Camera camera;
    /// <summary>
    /// оригинал fov
    /// </summary>
    [HideInInspector] public float origFov;
    /// <summary>
    /// величина поля зрения увеличивается при входе в бег
    /// </summary>
    public float FOVIncrease = 3f;
    /// <summary>
    /// количество времени, в течение которого поле зрения увеличивается
    /// </summary>
    public float TimeToIncrease = 1f;
    /// <summary>
    ///  количество времени, которое займет поле зрения, чтобы вернуться к своему первоначальному размеру
    /// </summary>
    public float TimeToDecrease = 1f;
    public AnimationCurve IncreaseCurve;


    public void Setup(Camera camera)
    {
        CheckStatus(camera);
        this.camera = camera;
        origFov = camera.fieldOfView;
    }

    void CheckStatus(Camera camera)
    {
        if (camera == null)
        {
            throw new Exception("FOVKick camera is null, please supply the camera to the constructor"); // FOVKick камера пуста, поставьте камеру конструктору
        }

        if (IncreaseCurve == null)
        {
            throw new Exception("FOVKick Increase curve is null, please define the curve for the field of view kicks"); //FOVKick Кривая увеличения равна нулю, пожалуйста, определите кривую для поля обзора "
        }
    }

    public void ChangeCamera(Camera camera)
    {
        this.camera = camera;
    }

    public IEnumerator FOVKickUp()
    {
        float t = Mathf.Abs((camera.fieldOfView - origFov) / FOVIncrease);
        while (t < TimeToIncrease)
        {
            camera.fieldOfView = origFov + (IncreaseCurve.Evaluate(t / TimeToIncrease) * FOVIncrease);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }



    public IEnumerator FOVKickDown()
    {
        float t = Mathf.Abs((camera.fieldOfView - origFov) / FOVIncrease);
        while (t > 0)
        {
            camera.fieldOfView = origFov + (IncreaseCurve.Evaluate(t / TimeToDecrease) * FOVIncrease);
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //make sure that fov returns to the original size
        camera.fieldOfView = origFov;
    }

}
