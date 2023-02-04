using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int life = 3;
    public void DropHair() { life--; }
}
