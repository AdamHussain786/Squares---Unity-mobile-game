using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public void Click()
    {
        AudioManager.instance.PlaySound("Click");
    }
}
