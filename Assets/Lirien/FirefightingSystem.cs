using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FirefightingSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _antifire;
    private bool isCor = false;
    private bool isFireComplited = false;

    private void Update()
    {
        if (isCor)
        {
            StartCoroutine(StopFire(1f));
            isCor = false;
        }

        if (isFireComplited)
        {
            StartCoroutine(StopAll(2f));
        }
    }


    IEnumerator StopFire(float value)
    {
        yield return new WaitForSeconds(value);
        _fire.startLifetime -= 0.05f;
        isCor = true;
        if (_fire.startLifetime <= 0.001)
        {
            isCor = false;
            _antifire.startLifetime = 0.0001f;
            isFireComplited = true;
        }
    }

    IEnumerator StopAll(float value)
    {
        yield return new WaitForSeconds(value);
        Destroy(gameObject);
    }

    public void IsFireStop()
    {
        isCor = true;
        _antifire.startLifetime = 1;
    }
}