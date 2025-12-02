using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _time;
    private float _damagePerSecond = 1;
    private float _timeBeTweenDamageTiks = 0.1f;

    private float _damagePerTick;

    private void Awake()
    {
        _damagePerTick = _damagePerSecond * _timeBeTweenDamageTiks;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            rocket.TakeDamage(_damagePerTick);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time += Time.deltaTime;

            if (_time > _timeBeTweenDamageTiks)
            {
                rocket.TakeDamage(_damagePerTick);

                _time = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time = 0;
        }
    }
}
