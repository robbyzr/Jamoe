using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{
    public GameObject Kunyitasam;
    public GameObject temulawak;
    public GameObject Kuncisirih;
    public GameObject resep;
    public GameObject petunjuk1;
    public GameObject petunjuk2;


    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void ResepKunyitasam()
    {
        Kunyitasam.SetActive(true);
        temulawak.SetActive(false);
    }
    public void ResepTemulawak()
    {
       temulawak.SetActive(true);
       Kunyitasam.SetActive(false);
        Kuncisirih.SetActive(false);
    }
    public void ResepKuncisirih()
    {
        Kuncisirih.SetActive(true);
        temulawak .SetActive(false);
    }

    public void PanelPetunjuk1()
    {
        petunjuk1.SetActive(true);
        resep.SetActive(false);
    }
    public void PanelPetunjuk2()
    {
        petunjuk2.SetActive(true);
        petunjuk1.SetActive(false);
    }
}
