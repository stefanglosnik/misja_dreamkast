using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public static bool prawo, lewo;
    // Start is called before the first frame update
    void Start()
    {
        prawo = false;
        lewo = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            prawo = false;
            lewo = false;
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Right")
        {
            prawo = true;
        }
        if(gameObject.name == "Left")
        {
            lewo = true;
        }
    }
}
