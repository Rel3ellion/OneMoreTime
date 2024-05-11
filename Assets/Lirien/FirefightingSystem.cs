using FMODUnity;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FirefightingSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _antifire;
    private bool isCor = false;
    public bool IsFireDone { get; private set; } = false;

    public GameObject invisibleWall;

    public StudioEventEmitter fire_alarm;
    public StudioEventEmitter fire_sound;
    public StudioEventEmitter fire_alarm_vo;

    private void Start()
    {
        fire_sound.Play();
        fire_alarm.Play();
        fire_alarm_vo.Play();
    }

    private void Update()
    {
        if (isCor)
        {
            StartCoroutine(StopFire(1f));
            isCor = false;
        }

        if (IsFireDone)
        {
            StartCoroutine(StopAll(2f));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("space key was pressed");
            fire_sound.Stop();
            fire_alarm.Stop();
            fire_alarm_vo.Stop();
            Destroy(invisibleWall);

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
            IsFireDone = true;
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