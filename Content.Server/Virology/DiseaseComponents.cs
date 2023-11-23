using Content.Shared.Xenoarchaeology.XenoArtifacts;
using Robust.Shared.Audio;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Virology;

public sealed partial class DiseaseComponent : Component
{
    [DataField("diseases")]
    public Disease[] Diseases;
}