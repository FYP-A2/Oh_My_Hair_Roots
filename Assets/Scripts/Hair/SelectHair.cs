using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectHair : MonoBehaviour
{
    [SerializeField]
    InputActionProperty mousePos;

    [SerializeField]
    InputActionProperty mouseLeft;

    [SerializeField]
    checkUI hairDisplayUI;

    // Start is called before the first frame update
    void Start()
    {
        mouseLeft.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        MouseClick();
    }

    void MouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePos.action.ReadValue<Vector2>());
        Physics.Raycast(ray, out hit, 1000);

        HairAround ha;
        Hair h;

        if (hit.collider == null)
            hairDisplayUI.nowHair = null;

        else if (hit.collider.transform.TryGetComponent<HairAround>(out ha))
        {
            hairDisplayUI.SetNowHair(ha.myHair);
        }
        else if (hit.collider.transform.parent != null)
        {
            if (hit.collider.transform.parent.parent != null)
                if (hit.collider.transform.parent.parent.TryGetComponent<Hair>(out h))
                {
                    hairDisplayUI.SetNowHair(ha.myHair);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
