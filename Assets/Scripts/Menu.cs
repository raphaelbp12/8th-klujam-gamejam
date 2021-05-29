using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private string _playSceneName;

    public void OnPlay()
    {
        SceneManager.LoadScene(_playSceneName);
    }
}
