namespace osuElements.Storyboards
{
    public class UndefinedEvent : EventBase
    {
        public string[] Lineparts;
        public UndefinedEvent(string[] lineparts) {
            Lineparts = lineparts;
        }
        public override string ToString() {
            return string.Join(",", Lineparts);
        }
    }
}
