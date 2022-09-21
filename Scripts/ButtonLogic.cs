using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    private GameObject player;
    public GameObject self;
    public float dist;
    public Transform tppos;
    public Transform uipos;

    public Color faded;
    public Color normal;

    public Color text;

    public GameObject fade;
    

    private ColorBlock colors;


    void Start()
    {
        player = GameObject.Find("XRRig");
        dist = 2.5f;
        colors = GetComponent<Button>().colors;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(player.transform.position, uipos.position) > dist ){
            colors.normalColor = faded;
            GetComponent<Button>().colors = colors;
            GetComponentInChildren<Text>().color = faded;
            
        }
        else{
            colors.normalColor = normal;
            GetComponent<Button>().colors = colors;
            GetComponentInChildren<Text>().color = text;
        }
    }

    public void TeleportUp(){
        player.transform.position=tppos.position;
    }
}
