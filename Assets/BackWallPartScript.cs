using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BackWallPartScript : MonoBehaviour
{
    public int x;
    public int y;
    public PartMaster master;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);   
        master.PlaceNewPart(x,y,false);
    }
    
}
