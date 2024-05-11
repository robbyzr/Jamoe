using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item storedItem;
    public string storedItemName;
    public CraftingManager craftingManager;


    //untuk menyimpan item yang di klik ke dalam slot
    public bool AddItemToSlot(Item item)
    {
        if (storedItem == null)
        {            
            storedItem = item;
            storedItemName = storedItem.itemName;
            gameObject.SetActive(true);
            //untuk menyimpan slot ke crafting manager
            craftingManager.StoreSlot(this);
            craftingManager.CheckForCreatedRecipes();
            return true; // Item berhasil ditambahkan
        }
        else
        {
            // Slot storage sudah terisi, item tidak dapat dimasukkan ke dalamnya
            return false; // Item tidak dapat ditambahkan
        }
    }

    public bool RemoveItemSlot(Item item)
    {
        if (storedItem != item)
        {
            storedItem = null;
            storedItemName = null;
            gameObject.SetActive(false);
            craftingManager.RemoveSlot(this);
            return true; // Item berhasil ditambahkan

        }
        else
        {
            // Slot storage sudah terisi, item tidak dapat dimasukkan ke dalamnya
            return false; // Item tidak dapat ditambahkan
        }
    }
 }
