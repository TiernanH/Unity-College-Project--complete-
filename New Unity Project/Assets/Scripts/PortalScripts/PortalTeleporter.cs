using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    private AudioSource portalAudio;
    public AudioClip teleportSound;

    public bool isOverlapping = false;

    private void Start()
    {
        portalAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player has entered the trigger zone
        if (isOverlapping)
        {
            //calculate the direction the player enters from the dot product
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //the dot product returns negative if it is from the side we want
            if(dotProduct < 0f)
            {
                //calculate the difference in the rotation of "this" portal to "other"
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                //the player has to come out the opposite side so flip it
                rotationDiff += 180;
                //rotate the player by the difference on the y axis
                player.Rotate(Vector3.up, rotationDiff);

                //calculate the offset position of player to portal
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                //teleport the player to the other portal based on that offset
                player.position = reciever.position + positionOffset;

                //no longer overlapping so it is false
                isOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //play the teleport sound
            portalAudio.PlayOneShot(teleportSound, 1.0f);
            //if the player collides with the portal then it is overlapping
            isOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //reset to false as soon as the player exites
            //this is nessecary to stop back and forth glitches
            isOverlapping = false;
        }
    }
}
