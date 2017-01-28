using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeMaster : MonoBehaviour {

    public Slider musikSlider;

    void Update() {
        
    }

    void Start()
    {
        
        float aktuellesVolumen = PlayerPrefs.GetFloat("MusicVolumen");
        if(aktuellesVolumen == 0)
        {
            musikSlider.value = 1f;
        }else
        {
            musikSlider.value = aktuellesVolumen;
        }
        
    }

    public void MusicVolumen (float newMusicVolumen)
    {
        
       PlayerPrefs.SetFloat("MusicVolumen", newMusicVolumen);
    }


}
