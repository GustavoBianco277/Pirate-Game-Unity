using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject PainelMenu;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("Duration"))
            PlayerPrefs.SetInt("Duration", 1);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void SettingButton()
    {
        PainelMenu.SetActive(true);
    }

    public void BackButton()
    {
        PainelMenu.SetActive(false);
    }

    public void RightButton(TMP_Dropdown DropDown)
    {
        int Value = DropDown.value;
        Value++;
        DropDown.value = DropDown.options.Count > Value ? Value : 0;
        PlayerPrefs.SetInt("Duration", DropDown.value);
    }

    public void LeftButton(TMP_Dropdown DropDown)
    {
        int Value = DropDown.value;
        Value--;
        DropDown.value = Value < 0 ? DropDown.options.Count : Value;
        PlayerPrefs.SetInt("Duration", DropDown.value);
    }
}
