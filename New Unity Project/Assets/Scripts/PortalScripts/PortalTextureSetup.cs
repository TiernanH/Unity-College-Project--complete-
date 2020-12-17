using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // this script applies to both portal render planes //
    // NOTE: Most of the fancy stuff is done by shaders //
    //////////////////////////////////////////////////////
 
    //pull in both cameras
    public Camera cameraB;
    public Camera cameraA;

    //pull in both materials
    public Material cameraMatB;
    public Material cameraMatA;


    // Start is called before the first frame update
    void Start()
    {
        //first of all reset it to nothing
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        //create a brand new texture based off of current dimensions
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //set the current texture to the one we want
        cameraMatA.mainTexture = cameraA.targetTexture;


        //the same as above
        if (cameraB.targetTexture != null) 
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }
}
