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


        public GeneticAlgorithm(int _populationSize, List<string> _sequencesToAlign, int _probabilityOfMutations) {
            this.populationSize = _populationSize;
            this.sequencesToAlign = _sequencesToAlign;
            this.numberOfSequencesToAlign = _sequencesToAlign.Count;
            // TODO try catch this
            this.sequenceLength = _sequencesToAlign[0].Length;
            //
            this.probabilityOfMutations = _probabilityOfMutations;
            this.bestFitness = 0;
        }

        //params
        private int populationSize;
        private int numberOfSequencesToAlign;  //from data grid view
        private int sequenceLength;     // sequence length from data grid view
        private int probabilityOfMutations;

        //params
        public List<Individual> population;

        public Individual BestAlignment { get; set; }

        private int bestFitness;

        public List<string> sequencesToAlign;

        public void runAlgorithm() {
            Random rnd = new Random();
            int mut;
            int iterations = 100000;
            this.createRandomPopulation();
            for (int it = 0; it < iterations; it++) {
                this.convertBoolToAlignment();
                this.fitnessFunction();
                this.selection();
                this.crossover();
                mut = rnd.Next(0, 101);
                if (mut <= probabilityOfMutations) {
                    mut = rnd.Next(0, populationSize);
                    population[mut] = mutation(population[mut]);
                }
                
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
            }
        }

        public void fitnessFunction() {
            List<char> nucleotidesInColumn = new List<char>();
            int misMatches = 0;
            double floatFit;
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
                floatFit = (1.0 - (Convert.ToDouble(misMatches) / (Convert.ToDouble(sequenceLength) * 2.0))) * 100.0;
                population[individual].fitness = Convert.ToInt32(floatFit);
                if (population[individual].fitness == 0)
                {
                    population[individual].fitness = 1;
                }
                if (population[individual].fitness > bestFitness) {
                    this.bestFitness = population[individual].fitness;
                    Console.WriteLine(bestFitness.ToString());
                    this.BestAlignment = population[individual]; 
                }
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


        public Individual mutation(Individual _individual) {
            Random rnd = new Random();
            int substOrTrans = 0;   // 0 = susbstitution, 1 = translocation
            substOrTrans = rnd.Next(0, 2);
            int row = rnd.Next(0, numberOfSequencesToAlign);    // number of sequence where mutation occurs
            if (substOrTrans == 0)
            {    // substitution
                int a = rnd.Next(0, sequenceLength * 2);
                int b = rnd.Next(0, sequenceLength * 2);
                int temp;
                while (_individual.matrix[row][a] == _individual.matrix[row][b])
                {
                    b = rnd.Next(0, sequenceLength * 2);
                }
                temp = a;
                a = b;
                b = temp;
            }
            else if (substOrTrans == 1)
            {   //translokacja
                List<bool> seqToTranslocate = new List<bool>();
                int from = rnd.Next(0, (sequenceLength * 2) - 1 );  //poczatek ciagu do przestawienia
                int to = rnd.Next(from + 1, sequenceLength * 2);    //koniec ciagu do przestawienia
                for (int i = from; i <= to; i++) {
                    seqToTranslocate.Add(_individual.matrix[row][i]);   //tworzymy liste zawierajaca sekwencje do przestawienia
                }
                _individual.matrix[row].RemoveRange(from, to - from + 1);   // usuwamy ja z pierwotnego dopasowania
                int where = rnd.Next(0, sequenceLength * 2);    //losujemy index gdzie ja wstawimy
                for (int j = where; j < where + seqToTranslocate.Count; j++) {
                    if (_individual.matrix[row].Count <= j)
                    {
                        _individual.matrix[row].Add(seqToTranslocate[j - where]);
                    }
                    else
                    {
                        _individual.matrix[row].Insert(j, seqToTranslocate[j - where]);   //wstawiamy
                    }
                }
                if (_individual.matrix[row].Count != sequenceLength * 2 || _individual.matrix[row].Count(i=>i.Equals(true)) != sequenceLength) {
                    Console.WriteLine("Blad przy translokacji");    //sprawdzamy czy wszystko jest ok
                }
            }
            else {
                Console.WriteLine("BLAD");
            }


            return _individual;
        }

        public Individual recombination(Individual _a, Individual _b) {
            Individual newborn = new Individual();
            Random rnd = new Random();
            for (int row = 0; row < numberOfSequencesToAlign; row++) {
                newborn.matrix.Add(new List<bool>());
                for (int i = 0; i < sequenceLength * 2; i++) {

                    newborn.matrix[row].Add(false); // tworzenie pustej macierzy
                }
            }
            int randomIndex;
            List<int> indexesOfTruesInMother = new List<int>();   // lista zawierajaca indeksy na ktorych wystepuja 1 u matki
            List<int> indexesOfTruesInFather = new List<int>();     // to samo u ojca
            for (int row = 0; row < numberOfSequencesToAlign; row++) {
                indexesOfTruesInMother.Clear();
                indexesOfTruesInFather.Clear();
                for (int i = 0; i < sequenceLength * 2; i++) {  // tworzymy wektory opisujace na ktorych indeksach mamy 1 w wektorach rodzicow
                    if (_a.matrix[row][i] == true)
                    {
                        indexesOfTruesInMother.Add(i);
                    }
                    if (_b.matrix[row][i] == true) {
                        indexesOfTruesInFather.Add(i);
                    }
                }
                while (newborn.matrix[row].Count(i=>i.Equals(true))<sequenceLength) {   // tak dlugo az nie ma wystarczajacej ilosci 1 w wektorze wynikowym
                    randomIndex = rnd.Next(0, indexesOfTruesInMother.Count);            // losujemy index z tablicy indexow; na taki indeks bedziemy chcieli wstawic 1 (od matki)
                    while (newborn.matrix[row][indexesOfTruesInMother[randomIndex]] == true) {  // ale jezeli na tym miejscu juz jest 1 to chcemy znalezc inne miejsce
                        randomIndex = rnd.Next(0, indexesOfTruesInMother.Count);
                    }
                    newborn.matrix[row][indexesOfTruesInMother[randomIndex]] = true;    // wstawiamy 1
                    if (newborn.matrix[row].Count(i => i.Equals(true)) == sequenceLength) { // jezeli liczba 1 jest odpowiednia to przerywamy. Jezeli nie to kontynuujemy z ojcem
                        break;
                    }
                    randomIndex = rnd.Next(0, indexesOfTruesInFather.Count);
                    while (newborn.matrix[row][indexesOfTruesInFather[randomIndex]] == true)
                    {
                        randomIndex = rnd.Next(0, indexesOfTruesInFather.Count);
                    }
                    newborn.matrix[row][indexesOfTruesInFather[randomIndex]] = true;
                }
            }

            return newborn;
        }

        public void crossover() {
            int indexA;
            int indexB;
            Individual newIndividual;
            List<Individual> newborns = new List<Individual>();
            Random rnd = new Random();
            int probability;
            while (population.Count + newborns.Count < populationSize) {
                probability = rnd.Next(0, 2*bestFitness+1);
                indexA = rnd.Next(0, population.Count);
                indexB = rnd.Next(0, population.Count);
                while (indexA == indexB) {
                    indexB = rnd.Next(0, population.Count);
                }
                if (probability <= population[indexA].fitness + population[indexB].fitness) // im lepiej dostosowane osobniki tym wieksza szansa ze sie skrzyzuja
                {
                    newIndividual = recombination(population[indexA], population[indexB]);
                    newborns.Add(newIndividual);
                }
            }
            for (int i = 0; i < newborns.Count; i++) {
                population.Add(newborns[i]);
            }

        }
    }
}
