using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Robust.Shared.Serialization;

namespace Content.Server.Virology
{
    [Serializable]
    [DataDefinition]
    public sealed partial class Diseases
    {
        [DataField("name")]
        public string Name;

        [DataField("description")]
        public string Description;

        private Symptom[] Symptoms;

        public readonly unsigned short Severity;

        public readonly unsigned short Stage;

        public readonly unsigned short Resistance;

        public readonly unsigned short StageSpeed;

        public readonly unsigned short Transmisson;

        public readonly Spread Spread;
    }
}