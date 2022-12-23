using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patternoffset : MonoBehaviour
{



    float y = 0.5f;
    float yOffset;

    void Update()
    {

     

        yOffset -= (Time.deltaTime * y) / 10f;
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, yOffset);
        gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, yOffset);
        gameObject.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));

      

    }
}