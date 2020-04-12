using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioClip _signaling;

    private AudioSource _alarmPlayer;

    private bool _isSignaling = false;

    private void Start()
    {
        _alarmPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(_isSignaling)
            _alarmPlayer.volume += Time.deltaTime;
        else
            _alarmPlayer.volume -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isSignaling = !_isSignaling;

            if(_isSignaling)
                _alarmPlayer.PlayOneShot(_signaling);

            if (_alarmPlayer.volume == 0 && !_isSignaling)
                _alarmPlayer.Stop();
        }
    }
}
