using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropDownResolutions;
    [SerializeField] Toggle toggleFullScreen;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider sliderVolume;
    Resolution[] supportedResolutions;
    private void Start()
    {
        AllSupportedResolutions();
        LoadPrefs();
    }

    void LoadPrefs()
    {
        int SavedRes = SavePrefs.LoadResolution(supportedResolutions.Length - 1);
        SelectResolution(SavedRes);
        dropDownResolutions.SetValueWithoutNotify(SavedRes);

        bool SavedFullScreen = SavePrefs.LoadFullScreen(true);
        Fullscreen(SavedFullScreen);
        toggleFullScreen.SetIsOnWithoutNotify(SavedFullScreen);

        float SavedVolume = SavePrefs.LoadVolume(0.8f);
        ChanceVolume(SavedVolume);
        sliderVolume.SetValueWithoutNotify(SavedVolume);

    }

    void AllSupportedResolutions()
    {
        List<string> resolutionsNames = new List<string>();
        supportedResolutions = Screen.resolutions;
        for (int i = 0; i < supportedResolutions.Length; i++)
            resolutionsNames.Add($"{supportedResolutions[i].width} x {supportedResolutions[i].height} ({supportedResolutions[i].refreshRate} Hz)");
        dropDownResolutions.ClearOptions();
        dropDownResolutions.AddOptions(resolutionsNames);
    }

    public void Fullscreen(bool inFullscreen)
    {
        Screen.fullScreen = inFullscreen;
        SavePrefs.SaveFullScreen(inFullscreen);
    }

    public void SelectResolution(int SelectedResolution)
    {
        Screen.SetResolution(
            supportedResolutions[SelectedResolution].width,
            supportedResolutions[SelectedResolution].height,
            Screen.fullScreen,
            supportedResolutions[SelectedResolution].refreshRate);
        SavePrefs.SaveResolution(SelectedResolution);
    }

    public void ChanceVolume (float newVolume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(newVolume) * 20);
        SavePrefs.SaveVolume(newVolume);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
