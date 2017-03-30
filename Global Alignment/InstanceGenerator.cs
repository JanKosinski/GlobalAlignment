using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Alignment
{
    class InstanceGenerator
    {
        public static List<string> createInstance(string _randomSequence, uint _numberOfSequences) {
            List<string> sequences = new List<string>();
            Random rnd = new Random();
            string sequence = "";
            List<bool> currentRandomBoolVector = new List<bool>();
            for (int i = 0; i < _numberOfSequences; i++) {
                sequence = "";
                currentRandomBoolVector = SharedMethods.createRandomBooleanVector(_randomSequence.Length, Convert.ToUInt32(Convert.ToInt32(_randomSequence.Length)/2), rnd);
                for (int j = 0; j < currentRandomBoolVector.Count; j++) {
                    if (currentRandomBoolVector[j]) {
                        sequence += _randomSequence[j];
                    }
                }
                sequences.Add(sequence);
            }
            return sequences;
        }
    }
}
