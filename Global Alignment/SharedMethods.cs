using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Alignment
{
    static class SharedMethods
    {
        public static List<bool> createRandomBooleanVector(int _vectorLength, uint _numberOfTrues, Random _rnd)
        {
            List<bool> myVector = new List<bool>();
            int randomNumber;
            List<int> tIndexes = new List<int>();   // list of indexes in myVector where trues should be inserted
            for (int i = 0; i < _vectorLength; i++)
            {   // initializing vector with false values
                myVector.Add(false);
            }
            for (int j = 0; j < _numberOfTrues; j++)
            {  // lottery where trues should be inserted
                randomNumber = _rnd.Next(_vectorLength);
                while (tIndexes.Contains(randomNumber))
                { // if index already exists in myVector
                    randomNumber = _rnd.Next(_vectorLength);
                }
                tIndexes.Add(randomNumber);
            }
            for (int k = 0; k < tIndexes.Count; k++)
            {
                myVector[tIndexes[k]] = true;   // inserting true values 
            }
            return myVector;
        }

        public static string randomNucleotideSequence(uint _sequenceLength, string _type="dna") {
            string seq = "";
            Random random = new Random(); // time based "random" numbers
            int randomInt;
            char nucleotide = 'N';
            for (uint i = 0; i < _sequenceLength; i++) {
                randomInt = random.Next(4);
                switch (randomInt) {
                    case 0:
                        nucleotide = 'A';
                        break;
                    case 1:
                        nucleotide = (_type == "rna") ? 'U' : 'T';
                        break;
                    case 2:
                        nucleotide = 'G';
                        break;
                    case 3:
                        nucleotide = 'C';
                        break;
                }
                seq+=nucleotide;
            }
            return seq;
        }

        public static bool misMatch(List<char>_nucleotides, List<char>_items)
        { // looking for mismatches in _nucleotides. _items contains IUPAC characters which cannot be in _nucleotides. If they are, the mismatch is present. See compareNucleotidesIUPAC
            for (int i = 0; i < _items.Count; i++) {
                if ( _nucleotides.Contains(_items[i]) ) {
                    return true;
                }
            }
            return false;
        }

        public static bool compareNucleotidesIUPAC(List<char> _nucleotides)
        {    // returns true when there is no conflict between IUPAC characters in list
            List<char> items;
            if (_nucleotides.Contains('A') || _nucleotides.Contains('T') || _nucleotides.Contains('U') || _nucleotides.Contains('G') || _nucleotides.Contains('C'))
            {
                for (int i = 0; i < _nucleotides.Count; i++)
                {
                    switch (_nucleotides[i])
                    {
                        case 'A':
                            items = new List<char> { 'C', 'G', 'T', 'U', 'Y', 'S', 'K', 'B' };
                            if (misMatch(_nucleotides, items))
                            {
                                return false;
                            }
                            break;
                        case 'C':
                            items = new List<char> { 'A', 'G', 'T', 'U', 'R', 'W', 'K', 'D' };
                            if (misMatch(_nucleotides, items))
                            {
                                return false;
                            }
                            break;
                        case 'G':
                            items = new List<char> { 'A', 'T', 'C', 'U', 'Y', 'W', 'M', 'H' };
                            if (misMatch(_nucleotides, items))
                            {
                                return false;
                            }
                            break;
                        case 'T':
                            items = new List<char> { 'A', 'U', 'G', 'C', 'R', 'S', 'M', 'V' };
                            if (misMatch(_nucleotides, items))
                            {
                                return false;
                            }
                            break;
                        case 'U':
                            items = new List<char> { 'A', 'T', 'G', 'C', 'R', 'S', 'M', 'V' };
                            if (misMatch(_nucleotides, items))
                            {
                                return false;
                            }
                            break;
                    }
                }
            }
            else if (_nucleotides.Contains('R') || _nucleotides.Contains('Y') || _nucleotides.Contains('S') || _nucleotides.Contains('W') || _nucleotides.Contains('K') || _nucleotides.Contains('M'))
            {
                for (int i = 0; i < _nucleotides.Count; i++)
                {
                    switch (_nucleotides[i])
                    {
                        case 'R':
                            if (_nucleotides.Contains('Y')) {
                                return false;
                            }
                            break;
                        case 'Y':
                            if (_nucleotides.Contains('R')) {
                                return false;
                            }
                            break;
                        case 'S':
                            if (_nucleotides.Contains('W')) {
                                return false;
                            }
                            break;
                        case 'W':
                            if (_nucleotides.Contains('S')) {
                                return false;
                            }
                            break;
                        case 'K':
                            if (_nucleotides.Contains('M')) {
                                return false;
                            }
                            break;
                        case 'M':
                            if (_nucleotides.Contains('K')) {
                                return false;
                            }
                            break;
                    }
                }
            }
            return true;
        }
    }
}
