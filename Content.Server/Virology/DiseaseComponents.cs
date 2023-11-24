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
    public Disease[] DiseasesImmunity { get; set; } = new Disease[0];

    public void AddDisease(Disease newDisease)
    {
        Diseases.Append(newDisease);
    }

    public void AddDisease(Disease[] newDiseases)
    {
        Diseases = Diseases.Concat(newDiseases).ToArray();
    }

    public void AddDiseaseImmunity(Disease newImmunity)
    {
        DiseasesImmunity.Append(newImmunity);
    }

    public void AddDiseaseImmunity(Disease[] newImmunities)
    {
        DiseasesImmunity = DiseasesImmunity.Concat(newImmunities).ToArray();
    }
}

[RegisterComponent]
public sealed partial class HumanInfectableComponent : Component
{
    // Empty component to make sure that entity can infected and avoid mice infection
}
