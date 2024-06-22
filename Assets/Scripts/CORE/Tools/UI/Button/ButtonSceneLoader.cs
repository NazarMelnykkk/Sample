using UnityEngine;

public class ButtonSceneLoader : ButtonCustomBase
{
    [SerializeField] private SceneField _sceneToLoad;


    public override void Click()
    {
        base.Click();

        SceneLoader.Instance.Transition(_sceneToLoad, gameObject.scene.name);
    }
}
