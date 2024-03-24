using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightAlarm : MonoBehaviour
{
    [SerializeField] private float _flickeringSpeed = 1f;
    [SerializeField, Min(0)] private float _minIntensity = 0f;
    [SerializeField, Min(1)] private float _maxIntensity = 10f;

    private Light _light;
    private Coroutine _currentCoroutine = null;

    private void OnValidate()
    {
        float differenceStep = 1f;

        if (_minIntensity >= _maxIntensity)
            _minIntensity = _maxIntensity - differenceStep;
    }

    private void Start()
    {
        SetParameters();
    }

    public void SwitchOn()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(ChangeIntensity());
        }
        else
        {
            StopCoroutine(_currentCoroutine);

            _currentCoroutine = null;
            _light.intensity = _minIntensity;
        }
    }

    private void SetParameters()
    {
        _light = GetComponent<Light>();
        _light.intensity = _minIntensity;
        _light.color = Color.red;
    }

    private IEnumerator ChangeIntensity()
    {
        bool isWork = true;
        bool isLight = false;
        float interpolationValue = _flickeringSpeed * Time.deltaTime;

        while (isWork)
        {
            if (isLight)
            {
                Luminesce(_minIntensity, interpolationValue);
                isLight = TrySwitchMode(isLight, _minIntensity);
            }
            else
            {
                Luminesce(_maxIntensity, interpolationValue);
                isLight = TrySwitchMode(isLight, _maxIntensity);
            }

            yield return null;
        }
    }

    private void Luminesce(float targetValue, float interpolationValue)
    {
        _light.intensity = Mathf.MoveTowards(_light.intensity, targetValue, interpolationValue);
    }

    private bool TrySwitchMode(bool isLight, float targetValue)
    {
        if (_light.intensity == targetValue)
        {
            isLight = !isLight;
        }

        return isLight;
    }
}