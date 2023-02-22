using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject PainelMenu;

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
}
