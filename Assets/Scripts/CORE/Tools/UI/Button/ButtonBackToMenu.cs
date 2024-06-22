using UnityEngine;

public class ButtonBackToMenu : ButtonCustomBase
{
    [SerializeField] private SceneField _mainMenu;

    public override void Click()
    {
        base.Click();

        SceneLoader.Instance.Transition(_mainMenu, gameObject.scene.name);
    }

}
