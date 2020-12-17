using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;


    void Update()
    {
        //calculate the player offset 
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        //mimic that offset
        transform.position = portal.position + playerOffsetFromPortal;

        //get the difference in the angles of the portals
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        //use that difference to calculate rotational difference
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        //create a new direction to face based off of the rotation difference and the players forward direction
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;

        //set current rotation to that new rotation
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
       
    }
}
