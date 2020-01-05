using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScript : MonoBehaviour
{

    public Material SkyBox1;
    public Material SkyBox2;
 
    void Start()
    {
        RenderSettings.skybox = SkyBox1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("3"))
        {
            RenderSettings.skybox = SkyBox1;
            DynamicGI.UpdateEnvironment();
        }
        else
        if (Input.GetKeyDown("4"))
        {
            RenderSettings.skybox = SkyBox2;
            DynamicGI.UpdateEnvironment();
        }

        if(Input.GetKeyDown("5"))
        {
            RenderSettings.fog = !RenderSettings.fog;
        }
    }
}
