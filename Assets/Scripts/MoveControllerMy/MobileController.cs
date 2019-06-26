using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBG;
    [SerializeField]
    private Image joystick;
    private Vector2 joystick_InputVector;

    void Start()
    {
        joystickBG = GetComponent<Image>();
        //joystick.transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        joystick_InputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        // Touch on the joystick
        Vector2 positionJoystick;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform,ped.position, ped.pressEventCamera, out positionJoystick))
        {
            positionJoystick.x = (positionJoystick.x / joystickBG.rectTransform.sizeDelta.x);
            positionJoystick.y = (positionJoystick.y / joystickBG.rectTransform.sizeDelta.y);

            joystick_InputVector = new Vector2(positionJoystick.x * 2 , positionJoystick.y * 2);
            joystick_InputVector = (joystick_InputVector.magnitude > 1.0f) ? joystick_InputVector.normalized : joystick_InputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(joystick_InputVector.x * (joystickBG.rectTransform.sizeDelta.x / 2), joystick_InputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (joystick_InputVector.x != 0)
        {
            return joystick_InputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical()
    {
        if (joystick_InputVector.y != 0)
        {
            return joystick_InputVector.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}