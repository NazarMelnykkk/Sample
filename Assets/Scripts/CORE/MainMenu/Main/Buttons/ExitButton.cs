using UnityEngine;
public class ExitButton : ButtonCustomBase
{
    public override void Click()
    {
        base.Click();

        Application.Quit();
    }
}
