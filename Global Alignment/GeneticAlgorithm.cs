using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Alignment
{
    class GeneticAlgorithm
    {
        class Individual {
            public List<List<bool>> matrix;

            public Individual() {
                matrix = new List<List<bool>>();
            }
        }

        //params
        private int populationSize;
        private int numberOfSequencesToAlign;  //from data grid view
        private int sequenceLength;     // sequence length from data grid view

        //params
        private List<Individual> population;

        private List<string> sequencesToAlign;  

        public void createRandomPopulation() {
            population.Clear();
            Random rnd = new Random();
            for (int i = 0; i < populationSize; i++) {
                Individual indiv = new Individual();
                for (int j = 0; j < numberOfSequencesToAlign; j++) {
                    indiv.matrix.Add(SharedMethods.createRandomBooleanVector(sequenceLength*2, Convert.ToUInt32(sequenceLength), rnd));
                }
                population.Add(indiv);
            }
        }
    }
}
