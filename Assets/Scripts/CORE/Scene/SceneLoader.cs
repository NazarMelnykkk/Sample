using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [Header("Scene")]
    [SerializeField] private SceneField _systemScene;
    [SerializeField] private SceneField _menuScene;

    [Header("Actions")]
    public Action OnSceneLoadEvent;
    public Action OnSceneUnloadEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Add(_menuScene);
    }

    public void Add(SceneField sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.SceneName, LoadSceneMode.Additive);
    }

    public void Transition(SceneField sceneToLoad, string sceneToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
        SceneManager.LoadScene(sceneToLoad.SceneName, LoadSceneMode.Additive);
    }

    public void RestartGameScene(string sceneToRestart)
    {
        SceneManager.UnloadSceneAsync(sceneToRestart);
        SceneManager.LoadScene(sceneToRestart, LoadSceneMode.Additive);
    }

}