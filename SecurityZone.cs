using UnityEngine;

public class SecurityZone : MonoBehaviour
{
    [SerializeField] private GameObject _violator;

    private Alarm _alarm;

    private void Awake()
    {
        _alarm = GetComponentInChildren<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm.TurnOn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.TurnOff();
    }
}
