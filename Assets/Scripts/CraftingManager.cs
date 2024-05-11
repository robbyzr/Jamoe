using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraftingManager : MonoBehaviour
{
    public DragAndDrop parent;
    
    public List<Slot> slotList;
    public string[] recipes;
    public GameObject[] recipeResult;
    private GameObject cloneRecipeResult;


    public Slot resultSlot;
    public GameObject wrongRecipe;
    private GameObject cloneWrongRecipe;


    //untuk menyimpan slot ke dalam crafting manager
    public void StoreSlot(Slot slot)
    {              
        slotList.Add(slot);
    }

    //untuk menghapus slot yang ada didalam crafting manager
    public void RemoveSlot(Slot slot)
    {
        slotList.Clear();    
    }

    // function untuk membuat dan mengecek resep
    public void CheckForCreatedRecipes()
    {
        string currentRecipeString = "";
        foreach (Slot slot in slotList)
        {
            if (slot != null)
            {
                currentRecipeString += slot.storedItemName + ", ";
            }
        }
       
        int slotCount = slotList.Count;
        if (slotCount >= 3)
        {
            bool recipeMatched = false;
            
            //untuk mengecek setiap resep
            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] == currentRecipeString)
                {
                    parent.GetComponent<BoxCollider2D>().enabled = false;
                    cloneRecipeResult = Instantiate(recipeResult[i]);
                   
                    StartCoroutine(waitForASecond(i));
                    
                    recipeMatched = true;
                    break;
                }
            }

            //kondisi setelah mengecek resep dan tidak ada yang cocok
            if (!recipeMatched)
            {
                // Membuat instance clone dari wrongRecipe
                cloneWrongRecipe = Instantiate(wrongRecipe);                    

                // Menetapkan komponen Item dari wrongRecipe ke storedItem dalam resultSlot
                Item cloneWrongRecipeItem = cloneWrongRecipe.GetComponent<Item>();
                resultSlot.storedItem = cloneWrongRecipeItem;

                // Menonaktifkan parent dan mengaktifkan resultSlot
                parent.gameObject.SetActive(false);
                resultSlot.gameObject.SetActive(true);
            }

        }
            
    }

    IEnumerator waitForASecond(int i)
    {
        yield return new WaitForSeconds(3);
        Item itemComponent = recipeResult[i].GetComponent<Item>();
        // Menetapkan storedItem ke resultSlot
        resultSlot.storedItem = itemComponent;

        parent.gameObject.SetActive(false);
        resultSlot.gameObject.SetActive(true);
        
    }
}






