using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public int sceneBuildIndex;
    public Vector2 nextSpawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.Instance != null)
        {
            GameManager.Instance.NextSpawnPosition = nextSpawnPosition;
            StartCoroutine(LoadScene(sceneBuildIndex));
        }
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        GameManager.Instance.NextSpawnPosition = null;
    }
}
