using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuView : View
{
    [SerializeField] private Button playeButton;

    private ISceneLoaderService sceneLoaderService;

    [Inject]
    public void Consrtuct(ISceneLoaderService sceneLoaderService)
    {
        this.sceneLoaderService = sceneLoaderService;
    }

    private void OnEnable()
    {
        playeButton.onClick.AddListener(OnPlayClicked);
    }

    private void OnDisable()
    {
        playeButton.onClick.RemoveListener(OnPlayClicked);
    }

    public void OnPlayClicked()
    {
        sceneLoaderService.LoadSceneByType(SceneType.GameplayScene);
    }
}
