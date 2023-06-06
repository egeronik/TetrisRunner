using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 pos = new Vector2();
    public Transform playerTransform;
    public float xMultiplayer = 2;
    public float yMultiplayer = 2;
    public bool allowMovement = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        UpdatePlayer();
        
    }

    private void UpdatePos()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && pos.y<1)
        {
            pos.y += 1;
        }
        else if (Input.GetKeyDown(KeyCode.S)&& pos.y>0)
        {
            pos.y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D)&& pos.x<1)
        {
            pos.x += 1;
        }
        else if (Input.GetKeyDown(KeyCode.A)&& pos.x>-1)
        {
            pos.x -= 1;
        }
    }

    private void UpdatePlayer()
    {
        if (!allowMovement)
        {
            return;
        }
        playerTransform.position = new Vector3(pos.x * xMultiplayer, 1+pos.y * yMultiplayer, 0) ;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Part"))
        {
            
            allowMovement = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Part"))
        {
            allowMovement = true;
        }
    }
}
