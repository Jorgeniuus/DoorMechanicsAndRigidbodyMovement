using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInteraction : MonoBehaviour
{
    private float maxDistanceRay = 2.5f;

    private void FixedUpdate()
    {
        RayCastInteract();
    }

    private void RayCastInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;

        if (Physics.Raycast(ray, out hitPoint, maxDistanceRay))
        {
            Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward, Color.red);

             IDoorInteraction interactDoor = hitPoint.transform.GetComponent<IDoorInteraction>();

            if(interactDoor != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactDoor.IInteraction();
                }
            }

            if (hitPoint.collider.CompareTag("interactable"))
            {
                InteractText.Instance.ShowTextInteract(true);
            }
        }
        else
        {
            InteractText.Instance.ShowTextInteract(false);
        }
    }
}
