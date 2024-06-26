using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AlarmArea _alarmArea;
    [SerializeField] private LightAlarm _lightAlarm;
    [SerializeField] private SoundsAlarm _soundsAlarm;

    private void Awake()
    {
        _alarmArea = GetComponentInChildren<AlarmArea>();
        _lightAlarm = GetComponentInChildren<LightAlarm>();
        _soundsAlarm = GetComponentInChildren<SoundsAlarm>();
    }

    private void OnEnable()
    {
        _alarmArea.DetectedMotion += ChangeStatus;
    }

    private void OnDisable()
    {
        _alarmArea.DetectedMotion -= ChangeStatus;
    }

    private void ChangeStatus(Collider collider)
    {
        if (TryGetInruder(collider) == false)
            return;

        _lightAlarm.SwitchOn();
        _soundsAlarm.SwitchOn();
    }

    private bool TryGetInruder(Collider collider)
    {
        return collider != null && collider.TryGetComponent<Player>(out Player component);
    }
}
