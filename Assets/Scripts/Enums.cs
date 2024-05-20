namespace TrafficLights
{
    /// <summary>
    /// Traffic light state
    /// </summary>
    public enum LightState
    {
        Red,
        RedAmber,
        Amber,
        Green
    }

    /// <summary>
    /// Traffic light state's priority
    /// </summary>
    public enum LightStatePriority
    {
        Minor,
        Major
    }
}
