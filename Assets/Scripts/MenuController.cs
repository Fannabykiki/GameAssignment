using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [SerializeField] private GameObject confirmationPromt = null;


    [Header("Levels To Load")]
    public string PlayScence;
    private string levelToLoad;
    [SerializeField] private GameObject noSaveGameDialog = null;
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("PlayScene"))
        {
            levelToLoad = PlayerPrefs.GetString("PlayScene");
            SceneManager.LoadScene(1);
            

        }
        else
        {
            noSaveGameDialog.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //Show promt
        StartCoroutine(ConfirmationBox());
    }
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0f");
            VolumeApply();
        }
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPromt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPromt.SetActive(false);
    }
}
