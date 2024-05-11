using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string itemName;
    public GameObject bumbu;
    private GameObject cloneBumbu;

    public Transform parent;
    public Slot[] slots;



    public void OnMouseDown()
    {
        // Loop melalui setiap slot
        foreach (Slot slot in slots)
        {
            if (slot.AddItemToSlot(this))
            {
                // Cek apakah slot masih kosong
                if (slot.storedItem != null)
                {
                    // Instansiasi objek cloneBumbu
                    cloneBumbu = Instantiate(bumbu, parent);

                }
                break;
            }
        }
    }
}
