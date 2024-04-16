using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : HealthEventsHandler
{
    [SerializeField] private float _delay;

    private void Reset() =>
        _delay = 0;

    protected override void OnDie() =>
        StartCoroutine(ReloadScene(_delay));

    private IEnumerator ReloadScene(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
