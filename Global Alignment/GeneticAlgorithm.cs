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
            public int[] rouletteWheelSelectionRange;

            public Individual() {
                matrix = new List<List<bool>>();
                rouletteWheelSelectionRange = new int[2] {-1,-1};
            }
        }


        public GeneticAlgorithm(int _populationSize, List<string> _sequencesToAlign) {
            this.populationSize = _populationSize;
            this.sequencesToAlign = _sequencesToAlign;
            this.numberOfSequencesToAlign = _sequencesToAlign.Count;
            // TODO try catch this
            this.sequenceLength = _sequencesToAlign[0].Length;
            //
            
        }

        //params
        private int populationSize;
        private int numberOfSequencesToAlign;  //from data grid view
        private int sequenceLength;     // sequence length from data grid view

        //params
        public List<Individual> population;

        public List<string> sequencesToAlign;

        public void runAlgorithm() {
            int iterations = 10;
            this.createRandomPopulation();
            for (int it = 0; it < iterations; it++) {
                this.convertBoolToAlignment();
                this.fitnessFunction();
                
            }
        }

        public void createRandomPopulation() {
            population = new List<Individual>();
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
                population[individual].fitness = (1 - (misMatches / (sequenceLength*2) )) * 100;
            }
        }

        public int createRouletteWheelSelectionRanges() {
            int start = 0;
            int sum = 0;
            for (int i = 0; i < population.Count; i++) {
                population[i].rouletteWheelSelectionRange[0] = start;
                population[i].rouletteWheelSelectionRange[1] = start + population[i].fitness;
                start += population[i].fitness;
                sum += population[i].fitness;
            }
            return sum;
        }

        public void selection() {
            //metoda ruletki
            int sum = createRouletteWheelSelectionRanges();
            Random rnd = new Random();
            int rand = 0;
            List<int> toRemove = new List<int>();
            List<Individual> populationCopy = new List<Individual>();
            while (toRemove.Count < (populationSize / 2)) {
                rand = rnd.Next(0, sum + 1);
                for (int i = 0; i < population.Count; i++) {
                    if (rand > population[i].rouletteWheelSelectionRange[0] && rand <= population[i].rouletteWheelSelectionRange[1]) {
                        if (!toRemove.Contains(i)) {
                            toRemove.Add(i);
                            break;
                        }
                    }
                }
            }
            for (int j = 0; j < population.Count; j++) {
                if (!toRemove.Contains(j)) {
                    populationCopy.Add(population[j]);
                }
            }
            population = populationCopy;
        }
    }
}
