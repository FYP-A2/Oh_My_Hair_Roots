using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;
    float xRot, yRot, zRot;
    float x, y, z;
    Vector2 mPrevPos = Vector3.zero;
    Vector2 mPosDelta = Vector3.zero;
    public bool touched;
    public InputActionProperty mousePosition;
    public InputActionProperty lmb;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public int min, max;
    public int i;
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        touched = false;
        lmb.action.performed += Action_performed;
        RandomRot();
        InvokeRepeating("RandomRot", 5f, 15f);      
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition.action.ReadValue<Vector2>());
        RaycastHit hit;
        Physics.Raycast(ray,out hit, 1000);
        if (hit.transform.name == "Cloud")
            touched = true;
        else
            return;
        //throw new System.NotImplementedException();
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lmb.action.phase);
        //Debug.Log(InputActionPhase.Performed);
        if(lmb.action.phase == InputActionPhase.Waiting){
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            touched = false;
            min = 1;
            max = 5;
        }
        if (lmb.action.phase == InputActionPhase.Started && touched) 
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);            
            mPosDelta = mousePosition.action.ReadValue<Vector2>() - mPrevPos;
            x = mPosDelta.x;
            if(x>rotationSpeed)
                x=rotationSpeed;
            y = mPosDelta.y;
            if(y > rotationSpeed)
                y=rotationSpeed;
            Vector3 right = Vector3.Cross(Camera.main.transform.up, transform.position - Camera.main.transform.position);
            Vector3 up = Vector3.Cross(transform.position - Camera.main.transform.position, right);
            transform.rotation = Quaternion.AngleAxis(-x,up)*transform.rotation;
            transform.rotation = Quaternion.AngleAxis(y,right) * transform.rotation;
            min = 0;
            max = 0;
            RandomRot();
        }
        else
        {
            transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);           
        }
        mPrevPos = mousePosition.action.ReadValue<Vector2>();
    }

    void RandomRot()
    {
        i = Random.Range(min,max);
        switch (i)
        {
            case 0:
                xRot = 0;
                yRot = 0;
                zRot = 0;
                break;
            case 1:
                xRot = rotationSpeed;
                yRot = rotationSpeed;
                zRot = rotationSpeed;
                break;
            case 2:
                xRot = 0;
                yRot = 0;
                zRot = rotationSpeed;
                break;
            case 3:
                xRot = 0;
                yRot = rotationSpeed;
                zRot = rotationSpeed;
                break;
            case 4:
                xRot = 0;
                yRot = rotationSpeed;
                zRot = 0;
                break;           
            case 5:
                xRot = rotationSpeed;
                yRot = rotationSpeed;
                zRot = 0;
                break;
            case 6:
                xRot = rotationSpeed;
                yRot = 0;
                zRot = 0;
                break;
            default: 
                break;
        }       
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
}
