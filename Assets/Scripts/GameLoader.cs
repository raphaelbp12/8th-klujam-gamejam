using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ProgressEvent : UnityEvent<float> {}

public class GameLoader : MonoBehaviour
{
    [SerializeField] private ProgressEvent _progressEvent;
    
    private AsyncOperation _loadingOperation;
    private bool _playRequested;
    
    void Start()
    {
        _loadingOperation = SceneManager.LoadSceneAsync("Scenes/Cubinho");
        _loadingOperation.allowSceneActivation = false;
    }

    void Update()
    {
        _progressEvent?.Invoke(_loadingOperation.progress / 0.9f);
    }

    public void StartGame()
    {
        if (!_playRequested) {
            _playRequested = true;
            StartCoroutine(finishLoadingAndPlay());
        }
    }
    
    private IEnumerator finishLoadingAndPlay()
    {
        _loadingOperation.allowSceneActivation = true;
        yield return _loadingOperation;
    }
}
