using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 mousePosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        transform.position = mousePosition;
        if (mousePosition.y < 0)
        {
            mousePosition.y = 0;
        }
        //if (mousePosition.x < 0)
        //{
        //    mousePosition.x = 0;
        //}
        //if (mousePosition.z < 0)
        //{
        //    mousePosition.z = 0;
        //}
    }
}
