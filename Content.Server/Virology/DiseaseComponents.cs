using Robust.Shared.Audio;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using System.Linq;
using Robust.Shared.Serialization;
using Robust.Shared.GameObjects;

namespace Content.Server.Virology;

[RegisterComponent]
public sealed partial class DiseaseComponent : Component
{
    [DataField]
    public Disease[] Diseases { get; set; } = new Disease[0];
    [DataField]
    public Disease[] DisseasesImmunity { get; set; } = new Disease[0];
    public DiseaseComponent(Disease disease)
    {
        Diseases.Append(disease);
    }
    public DiseaseComponent()
    {

    }
}

[RegisterComponent]
public sealed partial class HumanInfectableComponent : Component
{
    // Empty component to make sure that entity can infected and avoid mice infection
}
