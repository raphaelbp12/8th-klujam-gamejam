using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Pet))]
public class VFXController : MonoBehaviour
{
    [SerializeField] private GameObject _happyEffect;
    [SerializeField] private GameObject _sadEffect;

    private Pet _pet;

    private void Awake()
    {
        _pet = GetComponent<Pet>();
    }

    private void OnEnable()
    {
        _pet.ValidCardUsed += OnValidCard;
        _pet.InvalidCardUsed += OnInvalidCard;
    }

    private void OnDisable()
    {
        StopCoroutine(PlaySadEffect());
        _sadEffect.SetActive(false);
        _happyEffect.SetActive(false);

        _pet.ValidCardUsed -= OnValidCard;
        _pet.InvalidCardUsed -= OnInvalidCard;
    }

    private void OnInvalidCard(Card _)
    {
        _happyEffect.SetActive(false);

        StartCoroutine(PlaySadEffect());
    }

    private void OnValidCard(Card _)
    {
        StopCoroutine(PlaySadEffect());
        _sadEffect.SetActive(false);

        _happyEffect.SetActive(true);
        _happyEffect.GetComponent<VisualEffect>().Play();
    }

    private IEnumerator PlaySadEffect()
    {
        _sadEffect.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        _sadEffect.SetActive(false);
    }
}
