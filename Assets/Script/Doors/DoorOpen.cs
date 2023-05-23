using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IDoorInteraction
{
    [SerializeField] private Animator doorOpen;
    private bool openDoor = false;

    public void IInteraction()
    {
        InputDoor();
    }

    private void InputDoor()
    {
        openDoor = !openDoor;
        if (openDoor)
        {
            doorOpen.SetBool("open", true);
            SoundManager.Instance.SoundOpenDoor();
        }
        else
        {
            doorOpen.SetBool("open", false);
            SoundManager.Instance.SoundOpenDoor();
        }
    }
}
