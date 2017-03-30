using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Alignment
{
    class InstanceGenerator
    {
        private string createRandomSequence(int _seqLength) {
            string sequence = "";
            int randomBase;
            for (int i = 0; i < _seqLength; i++) {
                Random rnd = new Random();
                randomBase = rnd.Next(4);
                switch (randomBase) {
                    case 0:
                        sequence += 'A';
                        break;
                    case 1:
                        sequence += 'T';
                        break;
                    case 2:
                        sequence += 'G';
                        break;
                    case 3:
                        sequence += 'C';
                        break;
                }
            }
            return sequence;
        }

        private List<bool> createRandomBooleanVector(int _vectorLength, int _numberOfTrues) {
            List<bool> myVector = new List<bool>();
            Random rnd = new Random();
            int randomNumber;
            List<int> tIndexes = new List<int>();   // list of indexes in myVector where trues should be inserted
            for (int i = 0; i < _vectorLength; i++) {   // initializing vector with false values
                myVector.Add(false);
            }
            for (int j = 0; j < _numberOfTrues; j++) {  // lottery where trues should be inserted
                randomNumber = rnd.Next(_vectorLength);
                while (myVector[randomNumber]) { // if index already exists in myVector
                    randomNumber = rnd.Next(_vectorLength);
                }
                tIndexes.Add(j);
            }
            for (int k = 0; k < tIndexes.Count; k++) {
                myVector[tIndexes[k]] = true;   // inserting true values 
            }
            return myVector;
        }
    }
}
