using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public AudioMixer audioTemp;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for(int index =0; index <resolutions.Length; index++)
        {
            string option = resolutions[index].width + " x " + resolutions[index].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
        
    }
    public void backToHome()
    {
        int orderScene = 0;
        SceneManager.LoadScene(orderScene);
    }
    public void setVolume(float volume)
    {
        audioTemp.SetFloat("volume", volume); 
    }
    
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
