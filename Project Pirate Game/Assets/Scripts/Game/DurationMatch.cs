using UnityEngine;

public class DurationMatch : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI DurationText;

    private float Sec = 60, Min = 0;

    void Start()
    {
        Min = PlayerPrefs.GetInt("Duration");
    }

    void Update()
    {
        Sec -= Time.deltaTime;

        if (Sec <= 0)
        {
            Min -= 1;
            Sec = 59;
        }
        string min = Min >= 10 ? Min.ToString() : $"0{Min}";
        string sec = Sec >= 9.5f ? Sec.ToString("F0") : $"0{Sec:F0}";
        DurationText.text = $"{min}:{sec}";
    }
}
