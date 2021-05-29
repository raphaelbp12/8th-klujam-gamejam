using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Select Card")]
    public List<AudioClip> _audioSeletCard;
    [SerializeField]
    private AudioSource _selectCardAudioSouce;

    public void PlaySelectCard()
    {
        _selectCardAudioSouce.clip = _audioSeletCard[Random.Range(0, _audioSeletCard.Count)];
        _selectCardAudioSouce.Play();
    }

    [Header("Use Good Card")]
    public List<AudioClip> _audioGoodCard;
    [SerializeField]
    private AudioSource _goodCardAudioSouce;

    public void PlayGoodCard()
    {
        _goodCardAudioSouce.clip = _audioGoodCard[Random.Range(0, _audioGoodCard.Count)];
        _goodCardAudioSouce.Play();
    }

    [Header("Use Bad Card")]
    public List<AudioClip> _audioBadCard;
    [SerializeField]
    private AudioSource _badCardAudioSouce;

    public void PlayBadCard()
    {
        _badCardAudioSouce.clip = _audioBadCard[Random.Range(0, _audioBadCard.Count)];
        _badCardAudioSouce.Play();
    }


}
