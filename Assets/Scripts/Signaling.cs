using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioClip _signaling;
    AudioSource audioSource;
    private bool _isSignaling = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(_isSignaling)
            audioSource.volume += Time.deltaTime;
        else
            audioSource.volume -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isSignaling = !_isSignaling;
            if(_isSignaling)
                audioSource.PlayOneShot(_signaling);
            if (audioSource.volume == 0 && !_isSignaling)
                audioSource.Stop();
        }
    }
}
