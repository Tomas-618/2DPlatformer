using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void Reset() =>
        _delay = 0;

    public void ReloadScene() =>
        StartCoroutine(WaitBeforeReloading(_delay));

    private IEnumerator WaitBeforeReloading(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
