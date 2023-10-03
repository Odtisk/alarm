using UnityEngine;

public class SecurityZone : MonoBehaviour
{
    private Alarm _alarm;

    private void Awake()
    {
        _alarm = GetComponentInChildren<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
            _alarm.TurnOn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
            _alarm.TurnOff();
    }
}
