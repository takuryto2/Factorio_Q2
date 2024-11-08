using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_DropDownRecipe : MonoBehaviour
{
    TMP_Dropdown dropdown;
    private S_CrafterBehaviour crafterRef;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        gameObject.SetActive(false);
        
    }
    public void ChangeDropdownVisibility(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            crafterRef = null;
            Ray mouseRay = new();
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<S_CrafterBehaviour>(out crafterRef))
                {
                    dropdown.ClearOptions();
                    AddRecipeToDropdown(crafterRef);
                    gameObject.SetActive(!gameObject.activeSelf);

                }
            }
        }
    }
    private void AddRecipeToDropdown(S_CrafterBehaviour crafter)
    {
        List<SO_Crafts> recipeList = crafter.allRecipe;
        List<string> recipeName = recipeList.ConvertAll<string>(new System.Converter<SO_Crafts, string>((recipe) => recipe.name));   
        dropdown.AddOptions(recipeName);
    }

    public void GiveRecipe()
    {
        crafterRef._recipeSelected=crafterRef.allRecipe[dropdown.value];
    }
}