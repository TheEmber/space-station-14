using Robust.Shared.Audio;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using System.Linq;
using Robust.Shared.Serialization;
using Robust.Shared.GameObjects;

namespace Content.Server.Virology;

[Serializable]
[DataDefinition]
public sealed partial class DiseaseComponent : Component
{
    [DataField]
    public Diseases[] Diseases { get; set; } = new Diseases[0];

    public override void Initialize()
    {
        base.Initialize();

        // Check for diseases and spread if not empty
        if (Diseases.Any())
        {
            SpreadDisease();
        }
    }
}