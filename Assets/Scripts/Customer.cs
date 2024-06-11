using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string[] menuItems; // Array nama item-menu yang tersedia
    public GameObject orderPrefab; // Prefab untuk menampilkan pesanan
    private GameObject currentOrder; // Objek pesanan saat ini
    private Vector3 orderOffset = new Vector2(1.5f, 2.5f); // Penyesuaian posisi pesanan di atas customer
    public Sprite[] itemSprites; // Array sprite untuk item-menu yang tersedia
    public string orderedItemName;
    private GameManager gameManager;
    public Animator animator;
    
    public Animator animator2;

    public float angryLevel = 2f; // Tingkat kemarahan awal
    public float timer = 10f; // Timer awal
    private bool orderCompleted = false; // Apakah pesanan sudah selesai

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // Memunculkan pesanan saat customer muncul di layar
        DisplayOrder();
    }

   

    // Menampilkan pesanan
    void DisplayOrder()
    {
        // Pilih nama item secara acak dari menu
        orderedItemName = menuItems[Random.Range(0, menuItems.Length)];
        Debug.Log(orderedItemName);

        // Dapatkan indeks dari item-menu yang dipesan dalam array menuItems
        int itemIndex = System.Array.IndexOf(menuItems, orderedItemName);

        // Dapatkan sprite yang sesuai dari array itemSprites
        Sprite orderedItemSprite = itemSprites[itemIndex];

        // Hitung posisi pesanan di atas customer
        Vector3 orderPosition = transform.position + orderOffset;

        // Instantiate prefab pesanan di posisi yang ditentukan
        currentOrder = Instantiate(orderPrefab, orderPosition, Quaternion.identity);

        // Set sprite pesanan pada objek prefab pesanan
        currentOrder.GetComponent<SpriteRenderer>().sprite = orderedItemSprite;

        // Mulai timer
        StartCoroutine(CustomerTimer());
    }

    IEnumerator CustomerTimer()
    {
        yield return new WaitForSeconds(timer);

        // Timer berakhir, pelanggan pergi
        if (!orderCompleted)
        {
            animator.SetBool("marah", true);
            StartCoroutine(waitForASecond());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Pastikan objek yang bersentuhan adalah pesanan
        Item orderItem = other.GetComponent<Item>();
        if (orderItem != null)
        {
            // Periksa apakah nama pesanan ada dalam daftar item-menu yang tersedia
            if (orderedItemName == orderItem.itemName)
            {
                
                animator.SetBool("senang", true);
                animator2.SetBool("benar", true);
                StartCoroutine(waitForASecond());
                // Pesanan cocok dengan salah satu item-menu yang tersedia
                orderCompleted = true;
                Destroy(other.gameObject); // Hancurkan pesanan yang cocok
                 // Hancurkan pesanan yang dipesan customer
                

                gameManager.ResetGelas();
                gameManager.DeleteObjectsWithTag();             
                gameManager.happy +=1;
 
            }
            else
            {
                animator.SetTrigger("salah");
                gameManager.ResetGelas();
                gameManager.DeleteObjectsWithTag();
                Destroy(other.gameObject);
                // Pesanan tidak cocok, kurangi tingkat kemarahan
                angryLevel -= 1f;
                if (angryLevel <= 0)
                {
                    animator2.SetBool("salah", true);
                    animator.SetBool("marah", true);
                    StartCoroutine(waitForASecond());
                }
            }
        }
    }

    void GoAway()
    {
        Destroy(gameObject);
        Destroy(currentOrder);
    }

    IEnumerator waitForASecond()
    {
        yield return new WaitForSeconds(2);
        GoAway();
    }
}