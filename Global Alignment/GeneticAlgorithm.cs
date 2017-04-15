using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Alignment
{
    public class GeneticAlgorithm
    {
        public class Individual {
            public List<List<bool>> matrix;
            public List<List<char>> alignment;
            public int fitness;

            public Individual() {
                matrix = new List<List<bool>>();
            }
        }

        //params
        private int populationSize;
        private int numberOfSequencesToAlign;  //from data grid view
        private int sequenceLength;     // sequence length from data grid view

        //params
        public List<Individual> population;

        private List<string> sequencesToAlign;

        public void runAlgorithm() {
            int iterations = 10000;
            this.createRandomPopulation();
            for (int it = 0; it < iterations; it++) {
                this.convertBoolToAlignment();
                this.fitnessFunction();
            }
        }

        public void createRandomPopulation() {
            population.Clear();
            Random rnd = new Random();
            for (int i = 0; i < this.populationSize; i++) {
                Individual indiv = new Individual();
                for (int j = 0; j < this.numberOfSequencesToAlign; j++) {
                    indiv.matrix.Add(SharedMethods.createRandomBooleanVector(sequenceLength*2, Convert.ToUInt32(sequenceLength), rnd));
                }
                population.Add(indiv);
                //TODO testy
            }
        }

        public void convertBoolToAlignment() {
            List<List<char>> alignment;
            List<char> currentRow;
            int nucleotideNum = 0;
            for (int individual = 0; individual < this.population.Count; individual++) {
                alignment = new List<List<char>>();
                for (int row = 0; row < population[individual].matrix.Count; row++) {
                    currentRow = new List<char>();
                    nucleotideNum = 0;
                    for (int col = 0; col < population[individual].matrix[row].Count; col++) {
                        if ((population[individual].matrix[row])[col])
                        {
                            currentRow.Add(sequencesToAlign[row].ElementAt(nucleotideNum));
                            nucleotideNum++;
                        }
                        else {
                            currentRow.Add('-');
                        }
                    }
                    alignment.Add(currentRow);
                }
                population[individual].alignment = alignment;
                //TODO testy
            }
        }

        public void fitnessFunction() {
            List<char> nucleotidesInColumn = new List<char>();
            int misMatches = 0;
            for (int individual = 0; individual < population.Count; individual++) {
                misMatches = 0;
                for (int column = 0; column < this.sequenceLength * 2; column++) {
                    nucleotidesInColumn = new List<char>();
                    for (int row = 0; row < this.numberOfSequencesToAlign; row++) {
                        nucleotidesInColumn.Add(population[individual].alignment.ElementAt(row).ElementAt(column));
                    }
                    if (!SharedMethods.compareNucleotidesIUPAC(nucleotidesInColumn))
                    {
                        misMatches++;
                    }
                }
                //TODO zmienic charakter funkcji fitness
                population[individual].fitness = misMatches;
                //TODO testy
            }
        }
    }
}
