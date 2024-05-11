using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isDragging = false;
    private Vector2 offset;
    private Vector2 initialPosition;
    private BoxCollider2D boxCollider;



    // Start is called before the first frame update
    void Start()
    {    
        // Simpan posisi awal objek gelas
        initialPosition = transform.position;
        // Dapatkan referensi ke BoxCollider
        boxCollider = GetComponent<BoxCollider2D>();

        if (gameObject.tag == "Gelas")
        {
            // Matikan BoxCollider saat mulai
            boxCollider.enabled = false;

            // Panggil method untuk menyalakan kembali BoxCollider setelah 3 detik
            Invoke("EnableBoxCollider", 3f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
 
    }
    private void OnMouseDown()
    {
        isDragging = true;
        offset = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        isDragging = false;
        //lalu kembalikan gelas ke posisi awal
        transform.position = initialPosition;
    }

    // Method untuk menyalakan kembali BoxCollider setelah 3 detik
    private void EnableBoxCollider()
    {
        boxCollider.enabled = true;
    }

}
