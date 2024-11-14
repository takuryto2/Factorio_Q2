using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_CraftButton : MonoBehaviour
{
    [SerializeField] private GameObject craftImage;
    [SerializeField] private Image buttonImage;

    private void Start() {
        craftImage.SetActive(false);
    }
    public void Pressed(InputAction.CallbackContext ctx) {
        if (ctx.started)
        {
            craftImage.SetActive(!craftImage.activeInHierarchy);
            buttonImage.color = craftImage.activeInHierarchy ? new Color(1, 0.92f, 0.13f) : Color.white;
        }
    }
}
