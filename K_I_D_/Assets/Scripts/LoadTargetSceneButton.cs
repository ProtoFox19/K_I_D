using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadTargetSceneButton : MonoBehaviour {

    public int sceneToLoad;
    public GameObject Screenshotgesperrt,Screenshotfrei;
    void Start()
    {

        if (sceneToLoad == -1){

        }
        else { 
            if (PlayerPrefs.GetInt(sceneToLoad.ToString()) == 1) {
                this.GetComponent<Button>().interactable = true;
                this.GetComponentInChildren<Text>().text = "\n\n\nHighscore:\n" + PlayerPrefs.GetInt("Level" + sceneToLoad);
                Screenshotgesperrt.SetActive(false);
                Screenshotfrei.SetActive(true);
            } else {
                this.GetComponent<Button>().interactable = false;
                this.GetComponentInChildren<Text>().text = "\n\n\nHighscore:\n" + PlayerPrefs.GetInt("Level"+sceneToLoad);  //Hier gucken ob vorher Level und Zahl zusammengefügt werden müssen, oder ob er das echt so kann
                Screenshotgesperrt.SetActive(true);
                Screenshotfrei.SetActive(false);
            }
        }
    }

	public void LoadSceneNum(int num) {

        if(num < 0 || num >= SceneManager.sceneCountInBuildSettings) {
            Debug.LogWarning("Kann die Scene Nummer" + num + "nicht laden, SceneManager hat nur" + SceneManager.sceneCountInBuildSettings + "scenen in den BuildSettings");
            return;
        }
        Time.timeScale = 1;
        LoadingScreenManager.LoadScene(num);

    }
}
