using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    public GameObject[] ParticleEffects;
    public AudioClip[] SoundEffects;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();

    }

    public void InteractingEffect(Transform position)
    {
        _audioSource.PlayOneShot(SoundEffects[2]);
        Instantiate(ParticleEffects[0], position);
    }



}
