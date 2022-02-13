using UnityEngine;
using TMPro;
using Dacen.Utility;

public class Timer : MonoBehaviour
{
    private float currentTime;
    private int displayTime;

    public TextMeshProUGUI textMesh;
    [HideInInspector] new public bool enabled = false;

    public static Timer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!enabled)
            return;

        currentTime += Time.deltaTime;
        if(currentTime >= displayTime + 1)
        {
            displayTime = Mathf.FloorToInt(currentTime);
            ShowTime();
        }
    }

    private void ShowTime() => textMesh.text = DacenUtility.ConvertToMinutesAndSeconds(displayTime);

    public int Stop()
    {
        enabled = false;
        return displayTime;
    }

    public void ResetTime()
    {
        currentTime = displayTime = 0;
        ShowTime();
    }
}
