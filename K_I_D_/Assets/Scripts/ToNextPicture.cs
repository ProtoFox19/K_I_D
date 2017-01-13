using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToNextPicture : MonoBehaviour {

    public GameObject _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, poly;

    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(-1);
    }


    public void OnFirstPictures(string num)
    {
        GameObject[] gameOb = new GameObject[] { _1, _2, _3, _4, _5, _6, _7, _8, _9};

        for (int i=0; i < 8; i++)
        {
            if (gameOb[i].name.Equals(num))
            {
                gameOb[i].SetActive(false);
                gameOb[i + 1].SetActive(true);
            }

        }

    }

    public void OnPictureNeun()
    {
            poly.SetActive(false);
            StartCoroutine(nextPictures());
    }

    IEnumerator nextPictures()
    {
        _9.SetActive(false);
        _10.SetActive(true);
        yield return new WaitForSeconds(1);
        _11.SetActive(true);
        _10.SetActive(false);
        yield return new WaitForSeconds(1);
        _12.SetActive(true);
        _11.SetActive(false);
        yield return new WaitForSeconds(1);
        _13.SetActive(true);
        _12.SetActive(false);
        yield return new WaitForSeconds(1);
        _14.SetActive(true);
        _13.SetActive(false);

        GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(2);

        LoadTargetSceneButton simulateButton = new LoadTargetSceneButton();
        simulateButton.LoadSceneNum(1);
    }

}
