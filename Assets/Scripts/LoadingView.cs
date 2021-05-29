using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class LoadingView : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    private float _lastProgress = -1f;

    private void Awake()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void OnProgressUpdate(float progress)
    {
        if (Mathf.Approximately(_lastProgress, progress))
            return;

        _lastProgress = progress;
        var progressText = progress.ToString("P");
        _text.SetText($"Loading... {progressText}");
    }
}
