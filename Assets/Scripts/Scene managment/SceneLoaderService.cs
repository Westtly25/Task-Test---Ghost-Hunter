using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneLoaderService : MonoBehaviour, ISceneLoaderService
{
    [SerializeField] private SceneData[] sceneData;

    public void LoadSceneByType(SceneType sceneType)
    {
        StartCoroutine(LoadScene((int)sceneType));
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}