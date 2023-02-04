using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Position : MonoBehaviour
{
    [SerializeField]
    InputActionProperty space;
    float posX, posY,posZ,rotX,rotY,rotZ,rotW;
    // Start is called before the first frame update
    void Start()
    {
        space.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Debug.Log(transform.name + " pos: " + posX + "," + posY + "," + posZ + " rot: " + rotX + "," + rotY + "," + rotZ + "," + rotW);
    }

    // Update is called once per frame
    void Update()
    {
        posX= transform.position.x;
        posY= transform.position.y;
        posZ= transform.position.z;
        rotX= transform.rotation.x;
        rotY= transform.rotation.y;
        rotZ= transform.rotation.z;
        rotW= transform.rotation.w;
    }

    private void OnEnable()
    {
        space.action.Enable();
    }
    private void OnDisable()
    {
        space.action.Disable();
    }
}
