using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{

    public Transform attachedTo;
    public int topOffset;

    public UnityEvent onDeath = new UnityEvent();
    public UnityEvent onValueChanged = new UnityEvent();

    void Start()
    {
        if (onValueChanged == null)
            onValueChanged = new UnityEvent();
        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    void Update()
    {
        if (attachedTo)
        {
            transform.position = Camera.main.WorldToScreenPoint(attachedTo.transform.position);
            transform.position = new Vector3(transform.position.x, transform.position.y + topOffset, transform.position.z);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(float hpMax, float currentHp)
    {
        Slider slider = GetComponent<Slider>();
        slider.value = (currentHp / hpMax);
        if (onValueChanged != null)
            onValueChanged.Invoke();
        if (slider.value <= 0 && onDeath != null)
            onDeath.Invoke();
    }
}
