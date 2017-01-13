using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenue : MonoBehaviour {

    //Die Panels die jeweils sichtbar und unsichtbar gemacht werden sollen
    public GameObject Hauptmenue, Levelmenue, Optionenmenue, Impressummenue, Level1, Level2, Level3;


    //Wenn auf Level geklickt wurde
    public void OnLevel(bool clicked)
    {
       
        if (clicked)
        {
            Levelmenue.SetActive(clicked);
            Hauptmenue.SetActive(!clicked);
            Optionenmenue.SetActive(!clicked);
            Impressummenue.SetActive(!clicked);
        }
        else
        {
            Levelmenue.SetActive(clicked);
            Hauptmenue.SetActive(!clicked);
            Optionenmenue.SetActive(clicked);
            Impressummenue.SetActive(clicked);
        }
    }

    //Wenn auf Obtionen geklickt wurde
    public void OnOptionen(bool clicked)
    {
        if (clicked)
        {
            Optionenmenue.SetActive(clicked);        //wird das OptionsmenuePanel sichtbar gemacht
            Hauptmenue.SetActive(!clicked);          //wird das HauptmenuePanel unsichtbar gemacht
            Impressummenue.SetActive(!clicked);
            Levelmenue.SetActive(!clicked);
        }
        else
        {
            Optionenmenue.SetActive(clicked);
            Hauptmenue.SetActive(!clicked);
            Impressummenue.SetActive(clicked);
            Levelmenue.SetActive(clicked);
        }
    }

    //Wenn auf Impressum geklickt wurde
    public void OnImpressum(bool clicked)
    {
        if (clicked)
        {
            Impressummenue.SetActive(clicked);
            Hauptmenue.SetActive(!clicked);
            Optionenmenue.SetActive(!clicked);
            Levelmenue.SetActive(!clicked);
        }
        else
        {
            Impressummenue.SetActive(clicked);
            Hauptmenue.SetActive(!clicked);
            Optionenmenue.SetActive(clicked);
            Levelmenue.SetActive(clicked);
        }
    }

    public void OnVerlassen()
    {
        Application.Quit();
    }


    /*Level Buttons*/

    public void OnLevel1()
    {

    }

    public void OnLevel2()
    {
       
    }

    public void OnLevel3()
    {

    }

    public void OnZuruecksetzen(bool clicked)
    {
        if (clicked)
        {
            PlayerPrefs.DeleteAll();
            Optionenmenue.SetActive(!clicked);
            Hauptmenue.SetActive(clicked);
            Impressummenue.SetActive(!clicked);
            Levelmenue.SetActive(!clicked);
            SceneManager.LoadScene(0);
        }
    }



}
