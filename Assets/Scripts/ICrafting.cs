using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ICrafting
{
    void BeginningCraft(SO_Crafts recipe);
    IEnumerator Crafting(SO_Crafts recipe);

    List<ItemType> EndCrafting(SO_Crafts recipe);

}
