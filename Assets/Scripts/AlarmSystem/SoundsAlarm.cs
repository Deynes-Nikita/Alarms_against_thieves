using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsAlarm : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _volumeChangeSpeed = 0.3f;
    [SerializeField, Min(0)] private float _minVolume = 0f;
    [SerializeField, Min(0.1f)] private float _maxVolume = 1f;

    private AudioSource _audioSource;

    private Coroutine _maxSoudsCoroutine = null;
    private Coroutine _minSoudsCoroutine = null;

    private void OnValidate()
    {
        float differenceStep = 0.1f;

        if (_maxVolume > 1f)
            _maxVolume = 1f;
        
        if (_minVolume >= _maxVolume)
            _minVolume = _maxVolume - differenceStep;
    }

    private void Start()
    {
        SetParameters();
    }

    public void SwitchOn()
    {
        if (_maxSoudsCoroutine == null)
        {
            if (_minSoudsCoroutine != null)
                StopCoroutine(_minSoudsCoroutine);

            _audioSource.Play();

            _maxSoudsCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
        else
        {
            StopCoroutine(_maxSoudsCoroutine);
            _maxSoudsCoroutine = null;

            _minSoudsCoroutine = StartCoroutine(ChangeVolume(_minVolume));

            if (_audioSource.volume <= _minVolume)
                _audioSource.Stop();
        }
    }

    private void SetParameters()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
        _audioSource.loop = true;
        _audioSource.clip = _audioClip;
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        float interpolationValue = _volumeChangeSpeed * Time.deltaTime;

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, interpolationValue);

            yield return null;
        }
    }
}
