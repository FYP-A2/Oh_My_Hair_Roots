using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Controll : MonoBehaviour
{
    public GameObject cloud, sun;
    bool sunIsHold, cloudIsHold;
    [SerializeField] InputActionProperty mousePosition;
    [SerializeField] InputActionProperty lmb;
    Vector2 mPrevPos = Vector3.zero;
    Vector2 mPostPos = Vector3.zero;

    [SerializeField] Texture2D sunCursorTexture, cloudCursorTexture;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        lmb.action.performed += Action_performed;
    }
    private void Action_performed(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition.action.ReadValue<Vector2>());
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000);
        if (hit.transform.name == "Cloud")
            cloudIsHold = true;
        else if (hit.transform.name == "Sun")
            sunIsHold = true;
        else
            return;
        //throw new System.NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {
        if (lmb.action.phase == InputActionPhase.Waiting)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            cloudIsHold = false;
            sunIsHold = false;
        }
        if (lmb.action.phase == InputActionPhase.Started)
        {
            mPostPos = mousePosition.action.ReadValue<Vector2>() - mPrevPos;
        }
        if (cloudIsHold)
        {
            Cursor.SetCursor(cloudCursorTexture, hotSpot, cursorMode);
        }
        if (sunIsHold)
        {
            Cursor.SetCursor(sunCursorTexture, hotSpot, cursorMode);
        }
        mPrevPos = mousePosition.action.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        mousePosition.action.Enable();
        lmb.action.Enable();
    }
    private void OnDisable()
    {
        mousePosition.action.Disable();
        lmb.action.Disable();
    }

    public Vector2 getmPrevPos()
    {
        return mPrevPos;
    }
    public Vector2 getmPostPos()
    {
        return mPostPos;
    }

    public bool getSunIsHold()
    {
        return sunIsHold;
    }

    public bool getCloudIsHold()
    {
        return cloudIsHold;
    }
}
