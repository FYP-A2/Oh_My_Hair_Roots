using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Controll : MonoBehaviour
{
    public GameObject cloud, sun;
    public int maxScroll, minScroll;
    public float sensitive;
    bool sunIsHold, cloudIsHold, moonIsHold;
    [SerializeField] InputActionProperty mousePosition;
    [SerializeField] InputActionProperty lmb;
    [SerializeField] InputActionProperty rmb;
    [SerializeField] InputActionProperty mWheel;
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
        string s;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition.action.ReadValue<Vector2>());
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000);

        if (hit.collider != null)
        {
            s = hit.transform.name;
            switch (s)
            {
                case "Cloud":
                    cloudIsHold = true;
                    break;
                case "Sun":
                    sunIsHold = true;
                    break;
                case "Moon":
                    moonIsHold = true;
                    break;
                default:
                    break;
            }
        }
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
            moonIsHold= false;
        }
        if (lmb.action.phase == InputActionPhase.Started)
        {
            mPostPos = mousePosition.action.ReadValue<Vector2>() - mPrevPos;
        }
        if (rmb.action.phase == InputActionPhase.Started)
        {
            mPostPos = mousePosition.action.ReadValue<Vector2>() - mPrevPos;
            Vector3 right = Vector3.Cross(Camera.main.transform.up, transform.position - Camera.main.transform.position);
            Vector3 up = Vector3.Cross(transform.position - Camera.main.transform.position, right);
            transform.rotation = Quaternion.AngleAxis(-mPostPos.x*sensitive, up) * transform.rotation;
            transform.rotation = Quaternion.AngleAxis(mPostPos.y*sensitive, right) * transform.rotation;
        }
        if (mWheel.action.phase == InputActionPhase.Performed)
        {
            if (Camera.main.transform.position.z > minScroll)
            {
                Camera.main.transform.position = new Vector3(0, 0, minScroll);
            }
            else if (Camera.main.transform.position.z < maxScroll)
            {
                Camera.main.transform.position = new Vector3(0, 0, maxScroll);
            }
            else
            {
                Camera.main.transform.position += new Vector3(0, 0, mWheel.action.ReadValue<float>() / 120f);
            }
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
        rmb.action.Enable();
        mWheel.action.Enable();
    }
    private void OnDisable()
    {
        mousePosition.action.Disable();
        lmb.action.Disable();
        rmb.action.Disable();
        mWheel.action.Disable();
    }

    public bool getLMBWaitingPhase()
    {
        return lmb.action.phase == InputActionPhase.Waiting;
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

    public bool getMoonIsHold()
    {
        return moonIsHold;
    }
}
