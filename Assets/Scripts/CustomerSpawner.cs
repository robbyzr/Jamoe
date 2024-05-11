using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefabs; // Array prefab pelanggan
    public Transform[] spawnPoints; // Array posisi untuk instansiasi pelanggan
    public float minSpawnTime = 1f; // Waktu minimum antara kedatangan pelanggan
    public float maxSpawnTime = 2f; // Waktu maksimum antara kedatangan pelanggan

    public int maxCustomers; // Batas maksimum jumlah pelanggan

    private GameObject[] spawnedCustomers; // Array untuk menyimpan referensi pelanggan yang ada di setiap titik spawner
    private int customerCount; // Jumlah pelanggan saat ini

    private void Start()
    {
        // Inisialisasi array spawnedCustomers
        spawnedCustomers = new GameObject[spawnPoints.Length];

        // Mulai pemanggilan fungsi untuk spawn pelanggan pada setiap titik spawner
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            InvokeRepeating("SpawnCustomer", Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    // Fungsi untuk menampilkan pelanggan baru pada posisi yang telah ditentukan
    private void SpawnCustomer()
    {
        // Memeriksa apakah jumlah pelanggan sudah mencapai batas maksimum
        if (customerCount >= maxCustomers)
            return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);

        // Memeriksa apakah sudah ada pelanggan di titik spawner saat ini
        if (spawnedCustomers[spawnIndex] == null)
        {
            // Memilih prefab pelanggan secara acak dari array customerPrefabs
            GameObject randomPrefab = customerPrefabs[Random.Range(0, customerPrefabs.Length)];

            // Memunculkan klon pelanggan pada posisi yang telah ditentukan
            spawnedCustomers[spawnIndex] = Instantiate(randomPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

            // Menambah jumlah pelanggan
            customerCount++;
        }
    }
}