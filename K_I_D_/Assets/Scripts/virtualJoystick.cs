using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class virtualJoystick : MonoBehaviour,  IDragHandler, IPointerUpHandler, IPointerDownHandler{

    private Image bgImage;
    private Image joystickImage;

    public Vector3 inputDirection{ set; get; }

    public virtual void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        Vector2 position = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out position)) {
            position.x = (position.x / bgImage.rectTransform.sizeDelta.x);
            position.y = (position.y / bgImage.rectTransform.sizeDelta.y);

            float x = (bgImage.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (bgImage.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

            inputDirection = new Vector3(x, y, 0);
            inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;
            joystickImage.rectTransform.anchoredPosition = new Vector3(inputDirection.x * (bgImage.rectTransform.sizeDelta.x / 3), inputDirection.y * (bgImage.rectTransform.sizeDelta.y / 3));

            //Debug.Log(inputDirection);
        }

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
       // Debug.Log("OnPointerDown");
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        //Debug.Log("OnPointerUp");
    }

    // Use this for initialization
    private void Start () {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        inputDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
