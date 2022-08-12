namespace LoadScreen.Scripts
{
    public class InteractorDisable : InteractApplier
    {
        public override void Switch(bool isActive) => gameObject.SetActive(isActive);
    }
}
