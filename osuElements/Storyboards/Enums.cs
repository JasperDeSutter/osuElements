namespace osuElements.Storyboards
{
    public enum EventTypes : byte //print as string in osb, as number in osu
    {
        Background = 0,
        Video = 1,
        Break = 2,
        Backgroundcolor = 3,
        Sprite = 4,
        Sample = 5,
        Animation = 6,
    }
    public enum EventLayer : sbyte //print as string
    {
        Undefined = -1,
        Background = 0,
        Fail = 1,
        Pass = 2,
        Foreground = 3,
    }
    public enum Origin : byte //print as string
    {
        TopLeft = 0,
        TopCentre = 5,
        TopRight = 3,
        CentreLeft = 2,
        Centre = 1,
        CentreRight = 7,
        BottomLeft = 8,
        BottomCentre = 4,
        BottomRight = 9
    }
    public enum Easing : byte //print as int
    {
        None = 0,
        In = 1,
        Out = 2,
    }
    public enum Looptypes : byte //print as string
    {
        LoopForever,
        LoopOnce,
    }
    public enum TransformTypes : ushort
    {
        Fade = 'F',
        Move = 'M',
        Rotate = 'R',
        Scale = 'S',
        Color = 'C',
        MoveX = 'X',
        MoveY = 'Y',
        VectorScale = 'V',
        Parameter = 'P',
        Loop = 'L',
        Trigger = 'T'
    }
    public enum ParameterTypes : byte
    {
        A, //Additive color blending
        H, //Horizontal flip
        V, //Vertical flip
    }
    public enum TriggerTypes : byte
    {
        HitSound = 1,
        Passing = 2,
        Failing = 3,
        HitObjectHit = 4,
    }
}