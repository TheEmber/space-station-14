using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using Robust.Shared.Serialization;
using Robust.Shared.Random;

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

        public short Severity;

        public short Stage;

        public short Resistance;

        public short StageSpeed;

        public short Transmission;

        //public readonly Spread Spread;

        private const byte MaxSymptoms = 8;

        public void AddSymptom(Symptom newSymptom)
        {
            if(Symptoms.Contains(newSymptom))
            {
                // One disease cannot have 2 similar symptoms
                return;
            }
            if (Symptoms.Length == 8)
            {
                RemoveRandomSympoms(1);
            }
            Symptoms.Append(newSymptom);
            UpdateStats();
        }
        public void AddSymptom(Symptom[] newSymptoms)
        {
            var uniqueSymptoms = newSymptoms.Where(s => !Symptoms.Contains(s)).ToArray();

            if (Symptoms.Length + uniqueSymptoms.Length > MaxSymptoms)
            {
                // TODO: Add random symptomes mixing
            }
            else
            {
                Symptoms = Symptoms.Concat(uniqueSymptoms).ToArray();
            }
            UpdateStats();
        }

        private void RemoveRandomSympoms(int count)
        {
            if (Symptoms.Length < count)
            {
                // Not enough symptoms to remove
                return;
            }

            Random rand = new Random();

            Symptom[] newSymptoms = new Symptom[Symptoms.Length - count];

            // Copy all elements except the choosed by random ones
            for (int i = 0, j = 0; i < Symptoms.Length; i++)
            {
                if (j < count && rand.Next(Symptoms.Length - i) < count - j)
                {
                    j++;
                }
                else
                {
                    newSymptoms[i - j] = Symptoms[i];
                }
            }

            // Replace old symptoms with new array
            Symptoms = newSymptoms;
            // Update disease stats
            UpdateStats();
        }

        // Updates all stats of disease
        private void UpdateStats()
        {
            Severity = 0;
            Resistance = 0;
            StageSpeed = 0;
            Transmission = 0;
            foreach (var symptom in Symptoms)
            {
                Severity += symptom.Severity;
                Resistance += symptom.Resistance;
                StageSpeed += symptom.StageSpeed;
                Transmission += symptom.Transmission;
            }
        }
    }
}
