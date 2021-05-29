using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pet))]
public class PetReactionController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Pet _pet;
    
    private static readonly int HappyTriggerHash = Animator.StringToHash("Happy");
    private static readonly int SadTriggerHash = Animator.StringToHash("Sad");

    private void Awake()
    {
        if (_animator == null) {
            Debug.LogError("No animator set in PetReactionController", gameObject);
        }

        _pet = GetComponent<Pet>();
    }

    private void OnEnable()
    {
        _pet.ValidCardUsed += OnValidCard;
        _pet.InvalidCardUsed += OnInvalidCard;
    }

    private void OnDisable()
    {
        _pet.ValidCardUsed -= OnValidCard;
        _pet.InvalidCardUsed -= OnInvalidCard;
    }
    
    private void OnInvalidCard(Card _)
    {
        _animator.SetTrigger(SadTriggerHash);
    }
    
    private void OnValidCard(Card _)
    {
        _animator.SetTrigger(HappyTriggerHash);
    }
}
