[Serializable]
[DataDefinition]
public sealed partial class Symptom
{
    [DataField("name")]
    public string Name;

    [DataField("description")]
    public string Description;

    public readonly short Severity;

    public readonly short Resistance;

    public readonly short StageSpeed;

    public readonly short Transmission;

    public readonly short Level;
}
