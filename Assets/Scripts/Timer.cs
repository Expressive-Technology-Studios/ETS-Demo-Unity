using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI _timer;

    private void Awake()
    {
        _timer = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timer.text = "Timestamp: " + (Mathf.FloorToInt(Time.timeSinceLevelLoad) + 47);
    }
}
