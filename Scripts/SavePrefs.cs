using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs
{
    const string RESOLUTION = "RESOLUTION";
    const string FULLSCREEN = "FULLSCREEN";
    const string VOLUME = "VOLUME";

    // Resolução
    public static void SaveResolution(int currentResolution)
    {
        PlayerPrefs.SetInt(RESOLUTION, currentResolution);
    }

    public static int LoadResolution(int defaultResolution)
    {
        return PlayerPrefs.GetInt(RESOLUTION, defaultResolution);
    }

    //Tela cheia
    public static void SaveFullScreen(bool isFullScreen)
    {
        if (isFullScreen == true)
            PlayerPrefs.SetInt(FULLSCREEN, 1);
        else
            PlayerPrefs.SetInt(FULLSCREEN, 0);

    }

    public static bool LoadFullScreen(bool defaultFullScreen)
    {
        int defaultValueFullScreen = defaultFullScreen ? 1 : 0;
        int valueFullScreen = PlayerPrefs.GetInt(FULLSCREEN, defaultValueFullScreen);
        if (valueFullScreen == 1)
            return true;
        else
            return false;
    }

    //Volume
    public static void SaveVolume(float newVolume)
    {
        PlayerPrefs.SetFloat(VOLUME, newVolume);
    }

    public static float LoadVolume(float defaultVolume)
    {
        return PlayerPrefs.GetFloat(VOLUME, defaultVolume);
    }
}
