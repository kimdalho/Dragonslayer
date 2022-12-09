using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : SceneBase
{
    [SerializeField] Slider progressBar;

    public static string str;

    private void Start() 
    {
        SoundManager.Instance.audiosource.Stop();
        StartCoroutine(LoadScene(str)); 
    }

    IEnumerator LoadScene(string nextScene)
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false; float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null; 
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.value = Mathf.Lerp(progressBar.value, op.progress, timer);
                if (progressBar.value >= op.progress) { timer = 0f; }
            }
            else
            {
                progressBar.value = Mathf.Lerp(progressBar.value, 1f, timer);
                if (progressBar.value == 1.0f) { op.allowSceneActivation = true; yield break; }
            }
        }
       // SceneContianer.Instance.SetCurrentScene()
    }
}

