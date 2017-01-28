using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeEffekt : MonoBehaviour {

    public Slider effektSlider;

    void Update()
    {

    }

    void Start()
    {

        float aktuellesVolumen = PlayerPrefs.GetFloat("EffektVolumen");
        if(aktuellesVolumen == 0)
        {
            effektSlider.value = 1f;
        }else
        {
            effektSlider.value = aktuellesVolumen;
        }
        
    }

    public void EffektVolumen(float newEffektVolumen)
    {

        PlayerPrefs.SetFloat("EffektVolumen", newEffektVolumen);
    }


}