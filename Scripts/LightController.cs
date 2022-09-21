using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public Light spotLight;
    // Start is called before the first frame update
    void Start()
    {
        spotLight=GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        spotLight.transform.Rotate(0,0.4f,0, Space.World);
    }
}
