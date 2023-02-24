using UnityEngine;

public class DurationMatch : MonoBehaviour
{
    [Tooltip("Match duration text")]
    [SerializeField] TMPro.TextMeshProUGUI DurationText;

    [Tooltip("End of the game")]
    [HideInInspector] public bool EndOfGame;

    // Privates
    private Status Status;
    private float Sec = 59.9f, Min = 0;

    void Start()
    {
        Min = PlayerPrefs.GetInt("Duration");
        Status = FindObjectOfType<Status>();
    }

    void Update()
    {
        Clock();
    }

    private void Clock()
    {
        if (!EndOfGame)
        {
            Sec -= Time.deltaTime;

            if (Sec <= 0)
            {
                Min -= 1;
                Sec = 59;
            }
            string min = Min >= 10 ? Min.ToString() : $"0{Min}";
            string sec = Sec >= 9.5f ? Sec.ToString("F0") : $"0{Sec:0}";
            DurationText.text = $"{min}:{sec}";
        }

        if (Min < 0 && !EndOfGame)
        {
            EndOfGame = true;
            Status.ActivePanel("Victory");
            DurationText.text = $"00:00";
        }
    }

    public void ResetTime()
    {
        EndOfGame= false;
        Min = PlayerPrefs.GetInt("Duration");
        Sec = 59;
    }
}
