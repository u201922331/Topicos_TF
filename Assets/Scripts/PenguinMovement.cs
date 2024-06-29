using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovement : MonoBehaviour
{
    public int lifes = 3;
    public static PenguinMovement instance;
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    
    void Update()
    {
       Vector3 mousePosition = 
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
       mousePosition.y = transform.position.y;
       mousePosition.z = transform.position.y;
       mousePosition.x = Mathf.Clamp(mousePosition.x,
       -Camera.main.orthographicSize,
       Camera.main.orthographicSize);
       transform.position = mousePosition;

    }
}