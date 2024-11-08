using UnityEngine;
using UnityEngine.InputSystem;

public class PointerClick : MonoBehaviour
{

    S_ChangeMode Mode;
    Vector3 test;
    Vector3 dir;

    private void Start()
    {
        Mode = GetComponent<S_ChangeMode>();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            Ray mouseRay= new();
            mouseRay= Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                Mode.modeAction(hit);
            }
        }
    }
    
}
