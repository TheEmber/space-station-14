using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using Robust.Shared.Serialization;

namespace Content.Server.Virology
{
    [Serializable]
    [DataDefinition]
    public sealed partial class Disease
    {
        [DataField("name")]
        public string Name;

        [DataField("description")]
        public string Description;

        private Symptom[] Symptoms;

        public readonly short Severity;

        public readonly short Stage;

        public readonly short Resistance;

        public readonly short StageSpeed;

        public readonly short Transmisson;

        //public readonly Spread Spread;
    }

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
    }
}
