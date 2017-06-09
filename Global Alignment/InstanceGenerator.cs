using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Alignment
{
    class InstanceGenerator
    {
        public static List<string> createInstance(string _randomSequence, uint _numberOfSequences, uint _numOfErrors = 0, string _type = "dna") {
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

            List<int> randomNumSeq = new List<int>();
            List<int> randomNumNuc = new List<int>();
            StringBuilder sb;
            int randomNumberSeq;
            int randomNumberNuc;
            bool temp = false;
            for (int i = 0; i < _numOfErrors; i++) {
                randomNumberSeq = rnd.Next(sequences.Count);
                randomNumberNuc = rnd.Next(sequences[0].Length);
                temp = false;
                while (true)
                {
                    for (int k = 0; k < randomNumSeq.Count; k++)
                    {
                        if (randomNumberSeq == randomNumSeq[k] && randomNumberNuc == randomNumNuc[k]) {
                            temp = true;
                        }
                    }
                    if (!temp) { break; }
                    else { temp = false; }
                    randomNumberSeq = rnd.Next(sequences.Count);
                    randomNumberNuc = rnd.Next(sequences[0].Length);

                }
                randomNumSeq.Add(randomNumberSeq);
                randomNumNuc.Add(randomNumberNuc);
                sb = new StringBuilder(sequences[randomNumberSeq]);
                sb[randomNumberNuc] = substitute(sb[randomNumberNuc], _type);
                sequences[randomNumberSeq] = sb.ToString();
            }
            return sequences;
        }

        public static char substitute(char _charToChange, string _type = "dna") {
            char newChar;
            List<char> dnaIupuacNucs = new List<char> { 'A', 'T', 'G', 'C' };
            List<char> rnaIupuacNucs = new List<char> { 'A', 'U', 'G', 'C' };
            Random rnd = new Random();
            if (_type == "dna")
            {   
                newChar = dnaIupuacNucs[rnd.Next(dnaIupuacNucs.Count)];
            }
            else {
                newChar = rnaIupuacNucs[rnd.Next(rnaIupuacNucs.Count)];
            }
            while (newChar == _charToChange) {
                if (_type == "dna")
                {
                    newChar = dnaIupuacNucs[rnd.Next(dnaIupuacNucs.Count)];
                }
                else
                {
                    newChar = rnaIupuacNucs[rnd.Next(rnaIupuacNucs.Count)];
                }
            }
            return newChar;
        }
    }
}
