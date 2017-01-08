using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTargetSceneButton : MonoBehaviour {

	public void LoadSceneNum(int num) {
        if(num < 0 || num >= SceneManager.sceneCountInBuildSettings) {
            Debug.LogWarning("Kann die Scene Nummer" + num + "nicht laden, SceneManager hat nur" + SceneManager.sceneCountInBuildSettings + "scenen in den BuildSettings");
            return;
        }
        Time.timeScale = 1;
        LoadingScreenManager.LoadScene(num);

    }
}
