using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "joystick")]
public class JoystickValue : ScriptableObject
{
    public Vector2 joyTouch;
    public bool aTouch;
}
