using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [Tooltip("Menu panel")]
    [SerializeField] GameObject PainelMenu;

    [Tooltip("Match duration dropdown")]
    [SerializeField] TMP_Dropdown DurationMatch;

    [Tooltip("Time to spawn dropdown")]
    [SerializeField] TMP_Dropdown SpawnTime;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Duration"))
            DurationMatch.value = PlayerPrefs.GetInt("Duration");
        else
            PlayerPrefs.SetInt("Duration", 1);

        if (PlayerPrefs.HasKey("Spawntime"))
            SpawnTime.value = PlayerPrefs.GetInt("Spawntime") -1;
        else
            PlayerPrefs.SetInt("Spawntime", 1);
    }

    public void PlayButton()
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
        PlayerPrefs.SetInt("Duration", DurationMatch.value);
        PlayerPrefs.SetInt("Spawntime", SpawnTime.value +1);
    }

    public void RightButton(TMP_Dropdown DropDown)
    {
        int Value = DropDown.value;
        Value++;
        DropDown.value = DropDown.options.Count > Value ? Value : 0;
    }

    public void LeftButton(TMP_Dropdown DropDown)
    {
        int Value = DropDown.value;
        Value--;
        DropDown.value = Value < 0 ? DropDown.options.Count : Value;
    }
}
