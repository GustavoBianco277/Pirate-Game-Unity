using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Status : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI StatusText;
    public int Score;

    // Privates
    public Transform Player;
    private LifeSystem Life;
    private DurationMatch Match;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        Life = Player.GetComponent<LifeSystem>();
        Match = FindObjectOfType<DurationMatch>();
        FadeUI(0, 0);
    }

    public void ActivePanel(string Status)
    {
        ScoreText.text = $"Score: {Score}";
        StatusText.text = Status;
        Match.EndOfGame = true;
        Player.GetComponent<ShipMove>().Active = false;
        FadeUI();
    }

    private void FadeUI(float endValue = 1, float duration = 2)
    {
        foreach (Image img in GetComponentsInChildren<Image>())
        {
            img.DOFade(endValue, duration).OnComplete(() =>
            {
                if (img.transform.TryGetComponent<Button>(out var Button))
                {
                    if (endValue == 0)
                        Button.interactable = false;
                    else
                        Button.interactable = true;
                }
            });
        }

        foreach (TextMeshProUGUI TxT in GetComponentsInChildren<TextMeshProUGUI>())
        {
            TxT.DOFade(endValue, duration);
        }
    }

    public void PlayAgain()
    {
        FadeUI(0, 0);
        Life.DisableShip(false);
        Match.ResetTime();
        Player.localPosition = Vector3.zero;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
