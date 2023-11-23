using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Content.Server.Atmos.Reactions;
using Content.Shared.Atmos;
using Robust.Shared.Serialization;

namespace Content.Server.Diseases
{
    [Serializable]
    [DataDefinition]
    public sealed partial class Diseases
    {
        [DataField("name")]
        public string Name;

        [DataField("description")]
        public string Description;

        private Sympthom Sympthoms[];
    }
}