using System.Collections;
using System.Collections.Generic;

public interface ICrafting
{
    public Dictionary<ItemType,int> inventoryRessources { get;set; }
    void BeginningCraft(SO_Crafts recipe);
    IEnumerator Crafting(SO_Crafts recipe);

    List<ItemType> EndCrafting(SO_Crafts recipe);
}
