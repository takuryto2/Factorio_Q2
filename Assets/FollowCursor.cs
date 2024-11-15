using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    Camera cam;
    Ray cursorPos;
    RaycastHit hit;
    [SerializeField] S_GridManager gridAlignment;
    void Start()
    {
        cam=Camera.main;
        cursorPos = new ();

        
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cursorPos, out hit)) { transform.position = gridAlignment.AdjustToTile(hit.point)+new Vector3(0,0.1f,0); }
            
    }

}
