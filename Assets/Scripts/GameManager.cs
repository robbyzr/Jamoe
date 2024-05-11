using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public CraftingManager craftingManager;
    private string tagToDelete = "Bumbu";
    public GameObject gelasKosong;
    public Slot[] slots;
    
    public int happy;
    public int maxHappy;

    public GameObject winPanel;
    public GameObject losePanel;
    public Text happyText;

    public Text timerText; // Referensi ke UI Text untuk menampilkan timer
    public float timerDuration = 120f; // Durasi timer dalam detik
    private float timer; // Variabel untuk menyimpan waktu tersisa

    public GameObject panelPetunjuk;


   


    void Start()
    {
        
            PanelPetunujuk();

        timer = timerDuration; // Atur timer ke durasi awal
    }
    
    public void Update()
    {
       
        // Kurangi waktu dari timer setiap frame
        timer -= Time.deltaTime;

        
        UpdateTimerUI();
        UpdateHappyUI();

        // Cek apakah waktu telah habis
        if (timer <= 0f)
        {
            Lose();
        }

        if (happy == maxHappy)
        {
            Win();
        }
       
    }
   
    // Method untuk memperbarui teks UI dengan nilai happy yang diperbarui
    private void UpdateHappyUI()
    {
        // Membuat string yang berisi nilai happy dan maxHappy yang dipisahkan dengan "/"
        string happyTextString = happy.ToString() + "/" + maxHappy.ToString();
        // Update teks UI Text dengan nilai happy yang diperbarui
        happyText.text = happyTextString;
    }
    private void UpdateTimerUI()
    {
        // Ubah waktu menjadi format menit:detik
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        // Update teks UI Text dengan waktu yang diperbarui
        timerText.text = minutes + ":" + seconds;
    }
    
    public void Win()
    {
        winPanel.SetActive(true);
        Paused();
        UnlockNewLevel();
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        
        Paused();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
    public void Paused()
    {
        Time.timeScale = 0.0f;
    }
    public void PanelPetunujuk()
    {
        panelPetunjuk.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResetGelas()
    {
        foreach (Slot slot in slots)
        {
            slot.RemoveItemSlot(GetComponent<Item>());
        }
        DeleteObjectsWithTag();
        craftingManager.RemoveSlot(GetComponent<Slot>());
        gelasKosong.GetComponent<BoxCollider2D>().enabled = true;
        gelasKosong.SetActive(true);
    }

    //untuk menghancurkan gameobject bumbu-bumbu yang terdapat di parent gelas kosong
    public void DeleteObjectsWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDelete);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
