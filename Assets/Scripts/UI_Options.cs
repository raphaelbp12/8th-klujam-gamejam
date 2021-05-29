using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_Options : MonoBehaviour
{
    [Header("InitialValues")]
    [SerializeField]
    [Range(-80, 20)]
    private float _masterVolume = -50;
    [SerializeField]
    [Range(-80, 20)]
    private float _soundVolume = -50;
    [SerializeField]
    [Range(-80, 20)]
    private float _musicVolume = -50;

    [Header("Configurations")]
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Slider _masterAudioSlider;
    [SerializeField]
    private Slider _soundAudioSlider;
    [SerializeField]
    private Slider _musicAudioSlider;

    [SerializeField]
    private GameObject _panelOptions;

    private void Awake()
    {
        _panelOptions.SetActive(false);
        InitalizeVolume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panelOptions.SetActive(!_panelOptions.activeSelf);
        }
    }

    private void InitalizeVolume()
    {
        if (Options.firstChange) Options.masterVolume = _masterVolume;
        if (Options.firstChange) Options.soundVolume = _soundVolume;
        if (Options.firstChange) Options.musicVolume = _musicVolume;

        UpdateMasterVolume(Options.masterVolume);
        UpdateMasterVolume(Options.soundVolume);
        UpdateMasterVolume(Options.musicVolume);
        _masterAudioSlider.value = Options.masterVolume;
        _soundAudioSlider.value = Options.soundVolume;
        _musicAudioSlider.value = Options.musicVolume;

        _masterAudioSlider.onValueChanged.AddListener(UpdateMasterVolume);
        _soundAudioSlider.onValueChanged.AddListener(UpdateSoundVolume);
        _musicAudioSlider.onValueChanged.AddListener(UpdateMusicVolume);
    }

    public void UpdateMasterVolume(float volume)
    {
        Options.masterVolume = volume;
        _audioMixer.SetFloat("masterVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        Options.soundVolume = volume;
        _audioMixer.SetFloat("soundVolume", volume);
    }
    public void UpdateMusicVolume(float volume)
    {
        Options.musicVolume = volume;
        _audioMixer.SetFloat("musicVolume", volume);
    }
}
