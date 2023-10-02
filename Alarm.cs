using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration = 5;

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audio;

    private Color _regularColor = Color.white;
    private Color _triggeredColor = Color.red;
    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _alarmVolume = 0;
    private int _percentage = 100;
    private WaitForSeconds _timeStep;
    private bool _hasViolator = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        _timeStep = new WaitForSeconds(_duration / _percentage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
        {
            StartCoroutine(Escalate());
            _hasViolator = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _hasViolator = false;
    }

    private IEnumerator Escalate()
    {
        while (_hasViolator)
        {
            IncreaseVolume();
            UpdateAlarmVolume();
            yield return _timeStep;
        }

        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {

        while (_hasViolator == false)
        {
            DecreaseVolume();
            UpdateAlarmVolume();
            yield return _timeStep;
        }

        StartCoroutine(Escalate());
    }

    private void UpdateAlarmVolume()
    {
        _spriteRenderer.color = Color.Lerp(_regularColor, _triggeredColor, _alarmVolume);
        _audio.volume = _alarmVolume;
    }

    private void IncreaseVolume()
    {
        float volumeStep = _maxVolume / _percentage;

        if (_alarmVolume < _maxVolume)
        {
            _alarmVolume += volumeStep;
        }
        else
        {
            _alarmVolume = _maxVolume;
        }
    }

    private void DecreaseVolume()
    {
        float volumeStep = _maxVolume / _percentage;

        if (_alarmVolume > _minVolume)
        {
            _alarmVolume -= volumeStep;
        }
        else
        {
            _alarmVolume = _minVolume;
        }
    }
}
