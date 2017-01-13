using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public int sceneToLoad;
    PlayerController playerC;
    HealthController hC;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            SetHighscore();
            LoadLevel();
        }
    }

    void SetHighscore()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        hC = GameObject.Find("Player").GetComponent<HealthController>();
        float zeit = playerC.getSpielzeit();
        float leben = hC.health;
        float score = 5000 - (zeit * 10) + (leben * 1000);      //Score Berechnung ... man könnte noch rumschrauben klappt aber ganz gut ...
        int newScore = (int)Mathf.Round(score);
        int oldScore = PlayerPrefs.GetInt("Level" + SceneManager.GetActiveScene().buildIndex);
        if (newScore > oldScore) { 
            PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex,newScore);
        }
    }


    void LoadLevel() {

        // SceneManager.LoadScene(sceneToLoad);
        

        if (PlayerPrefs.GetInt(sceneToLoad.ToString()) == 0) {
            PlayerPrefs.SetInt(sceneToLoad.ToString(), 1);
        }
        StartCoroutine(FadeOUT());
        
    }

    IEnumerator FadeOUT()
    {
        GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(2);

        LoadTargetSceneButton simulateButton = new LoadTargetSceneButton();
        PlayerPrefs.SetInt(sceneToLoad.ToString(), 1);
        simulateButton.LoadSceneNum(sceneToLoad);
    }

}
