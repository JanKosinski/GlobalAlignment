﻿using System;
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
            public int Fitness { get; set; }
            public int MisMatches { get; set; }
            public int AlignmentLen { get; set; } //shorter the better
            public long[] rouletteWheelSelectionRange;

            public Individual() {
                matrix = new List<List<bool>>();
                rouletteWheelSelectionRange = new long[2] {-1,-1};
            }
        }


        public GeneticAlgorithm(int _populationSize, List<string> _sequencesToAlign, int _probabilityOfMutations) {
            this.PopulationSize = _populationSize;
            this.sequencesToAlign = _sequencesToAlign;
            this.NumberOfSequencesToAlign = _sequencesToAlign.Count;
            this.SequenceLength = _sequencesToAlign[0].Length;
            this.ProbabilityOfMutations = _probabilityOfMutations;
            this.BestFitness = 0;
            this.BestAlignmentLen = this.SequenceLength * 2;
        }

        //params
        public int PopulationSize { get; set; }
        public int NumberOfSequencesToAlign { get; set; }  //from data grid view
        public int SequenceLength { get; set; }     // sequence length from data grid view
        public int ProbabilityOfMutations { get; set; }
        


        //params
        public List<Individual> population;

        public Individual BestAlignment { get; set; }

        public int BestFitness { get; set; }
        public int BestAlignmentLen { get; set; }

        public List<string> sequencesToAlign;

        /*public void runAlgorithm() {
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
                if (mut <= ProbabilityOfMutations) {
                    mut = rnd.Next(0, PopulationSize);
                    population[mut] = mutation(population[mut]);
                }
                
            }
        }*/

        public void createRandomPopulation() {
            population = new List<Individual>();
            Random rnd = new Random();
            for (int i = 0; i < this.PopulationSize; i++) {
                Individual indiv = new Individual();
                for (int j = 0; j < this.NumberOfSequencesToAlign; j++) {
                    indiv.matrix.Add(SharedMethods.createRandomBooleanVector(SequenceLength*2, Convert.ToUInt32(SequenceLength), rnd));
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
            int lenOfAlignment = SequenceLength*2;
            List<char> nucleotidesInColumn = new List<char>();
            int misMatches = 0;
            double floatFit;
            for (int individual = 0; individual < population.Count; individual++) {
                misMatches = 0;
                lenOfAlignment = SequenceLength * 2;
                for (int column = 0; column < this.SequenceLength * 2; column++) {
                    nucleotidesInColumn = new List<char>();
                    for (int row = 0; row < this.NumberOfSequencesToAlign; row++) {
                        nucleotidesInColumn.Add(population[individual].alignment.ElementAt(row).ElementAt(column));
                    }
                    if (!SharedMethods.compareNucleotidesIUPAC(nucleotidesInColumn))
                    {
                        misMatches++;
                    }
                    else {
                        if (nucleotidesInColumn.Count(i => i.Equals("-")) == nucleotidesInColumn.Count) {
                            lenOfAlignment--;
                        }
                    }
                }
                floatFit = (1.0 - (Convert.ToDouble(misMatches) / (Convert.ToDouble(SequenceLength) * 2.0))) * 100.0;
                population[individual].Fitness = Convert.ToInt32(floatFit);
                population[individual].MisMatches = misMatches;
                population[individual].AlignmentLen = lenOfAlignment;
                if (population[individual].Fitness == 0)
                {
                    population[individual].Fitness = 1;
                }
                if (population[individual].Fitness > BestFitness)
                {
                    this.BestFitness = population[individual].Fitness;
                    this.BestAlignment = population[individual];
                    this.BestAlignmentLen = lenOfAlignment;
                }
                else if (population[individual].Fitness == BestFitness && population[individual].AlignmentLen < BestAlignmentLen) {
                    this.BestFitness = population[individual].Fitness;
                    this.BestAlignment = population[individual];
                    this.BestAlignmentLen = lenOfAlignment;
                }
            }

        }

        public int createRouletteWheelSelectionRanges() {
            population.Sort((x, y) =>x.Fitness.CompareTo(y.Fitness));
            int factor = 0;
            int start = 0;
            for (int i = 0; i < population.Count; i++) {
                population[i].rouletteWheelSelectionRange[0] = start;
                population[i].rouletteWheelSelectionRange[1] = start + (population[i].Fitness * (population.Count-factor));
                factor++;
                start += (population[i].Fitness * (population.Count - factor));
            }
            return start;
        }

        public void selection() {
            //metoda ruletki
            int sum = createRouletteWheelSelectionRanges();
            Random rnd = new Random();
            int rand = 0;
            List<int> toRemove = new List<int>();
            List<Individual> populationCopy = new List<Individual>();
            while (toRemove.Count < (PopulationSize / 2)) {
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
                if (!toRemove.Contains(j))
                {
                    populationCopy.Add(population[j]);
                }
            }
            population = populationCopy;
        }


        public Individual mutation(Individual _individual) {
            Random rnd = new Random();
            int substOrTrans = 0;   // 0 = susbstitution, 1 = translocation
            substOrTrans = rnd.Next(0, 2);
            int row = rnd.Next(0, NumberOfSequencesToAlign);    // number of sequence where mutation occurs
            if (substOrTrans == 0)
            {    // substitution
                int a = rnd.Next(0, SequenceLength * 2);
                int b = rnd.Next(0, SequenceLength * 2);
                int temp;
                while (_individual.matrix[row][a] == _individual.matrix[row][b])
                {
                    b = rnd.Next(0, SequenceLength * 2);
                }
                temp = a;
                a = b;
                b = temp;
            }
            else if (substOrTrans == 1)
            {   //translokacja
                List<bool> seqToTranslocate = new List<bool>();
                int from = rnd.Next(0, (SequenceLength * 2) - 1 );  //poczatek ciagu do przestawienia
                int to = rnd.Next(from + 1, SequenceLength * 2);    //koniec ciagu do przestawienia
                for (int i = from; i <= to; i++) {
                    seqToTranslocate.Add(_individual.matrix[row][i]);   //tworzymy liste zawierajaca sekwencje do przestawienia
                }
                _individual.matrix[row].RemoveRange(from, to - from + 1);   // usuwamy ja z pierwotnego dopasowania
                int where = rnd.Next(0, SequenceLength * 2);    //losujemy index gdzie ja wstawimy
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
            }


            return _individual;
        }

        public Individual randomRecombination(Individual _a, Individual _b) {
            Individual newborn = new Individual();
            Random rnd = new Random();
            for (int row = 0; row < NumberOfSequencesToAlign; row++) {
                newborn.matrix.Add(new List<bool>());
                for (int i = 0; i < SequenceLength * 2; i++) {

                    newborn.matrix[row].Add(false); // tworzenie pustej macierzy
                }
            }
            int randomIndex;
            List<int> indexesOfTruesInMother = new List<int>();   // lista zawierajaca indeksy na ktorych wystepuja 1 u matki
            List<int> indexesOfTruesInFather = new List<int>();     // to samo u ojca
            for (int row = 0; row < NumberOfSequencesToAlign; row++) {
                indexesOfTruesInMother.Clear();
                indexesOfTruesInFather.Clear();
                for (int i = 0; i < SequenceLength * 2; i++) {  // tworzymy wektory opisujace na ktorych indeksach mamy 1 w wektorach rodzicow
                    if (_a.matrix[row][i] == true)
                    {
                        indexesOfTruesInMother.Add(i);
                    }
                    if (_b.matrix[row][i] == true) {
                        indexesOfTruesInFather.Add(i);
                    }
                }
                while (newborn.matrix[row].Count(i=>i.Equals(true))<SequenceLength) {   // tak dlugo az nie ma wystarczajacej ilosci 1 w wektorze wynikowym
                    randomIndex = rnd.Next(0, indexesOfTruesInMother.Count);            // losujemy index z tablicy indexow; na taki indeks bedziemy chcieli wstawic 1 (od matki)
                    while (newborn.matrix[row][indexesOfTruesInMother[randomIndex]] == true) {  // ale jezeli na tym miejscu juz jest 1 to chcemy znalezc inne miejsce
                        randomIndex = rnd.Next(0, indexesOfTruesInMother.Count);
                    }
                    newborn.matrix[row][indexesOfTruesInMother[randomIndex]] = true;    // wstawiamy 1
                    if (newborn.matrix[row].Count(i => i.Equals(true)) == SequenceLength) { // jezeli liczba 1 jest odpowiednia to przerywamy. Jezeli nie to kontynuujemy z ojcem
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

        /*public Individual[] recombination(Individual _a, Individual _b) {
            //CPC crossover operator used
            Individual[] offspring = new Individual[2];
            List<bool> L_up;
            List<bool> L_down;
            Individual offspring1 = new Individual();
            Individual offspring2 = new Individual();
            List<bool> newRow1;
            List<bool> newRow2;
            for (int row = 0; row < NumberOfSequencesToAlign; row++) {
                
                // creates Lup and Ldown lists
                L_up = new List<bool>();
                L_down = new List<bool>();
                for (int i = 0; i < SequenceLength * 2; i++) {
                    //lup
                    if (_a.matrix[row][i] == true && _b.matrix[row][i] == false)
                    {
                        L_up.Add(true);
                    }
                    else {
                        L_up.Add(false);
                    }//
                    //ldown
                    if (_a.matrix[row][i] == false && _b.matrix[row][i] == true)
                    {
                        L_down.Add(true);
                    }
                    else
                    {
                        L_down.Add(false);
                    }//  
                }
                //
                newRow1 = new List<bool>();
                newRow2 = new List<bool>();
                for (int j = 0; j < SequenceLength * 2; j++) {
                    if (L_up[j] == true || L_down[j] == true)
                    {
                        if (_a.matrix[row][j] == false)
                        {
                            newRow1.Add(true);
                        }
                        else {
                            newRow1.Add(false);
                        }

                        if (_b.matrix[row][j] == false)
                        {
                            newRow2.Add(true);
                        }
                        else
                        {
                            newRow2.Add(false);
                        }
                    }
                    else {
                        newRow1.Add(_a.matrix[row][j]);
                        newRow2.Add(_b.matrix[row][j]);
                        
                    }
                }
                //testy
                if (newRow1.Count(i => i.Equals(true)) != SequenceLength || newRow2.Count(i => i.Equals(true)) != SequenceLength)
                {
                    Console.WriteLine("Blad w krzyzowaniu" + Environment.NewLine);
                }
                if (newRow1.Count != SequenceLength*2 || newRow2.Count != SequenceLength*2)
                {
                    Console.WriteLine("Blad w krzyzowaniu 3");
                }
                //koniec testow
                offspring1.matrix.Add(newRow1);
                offspring2.matrix.Add(newRow2);

            }
            //testy
            if (offspring1.matrix.Count != NumberOfSequencesToAlign || offspring2.matrix.Count != NumberOfSequencesToAlign) {
                Console.WriteLine("Blad w krzyzowaniu 2");
            }
            //testy
            offspring[0] = offspring1;
            offspring[1] = offspring2;
            return offspring;
        }*/

        public void crossover() {
            int indexA;
            int indexB;
            List<Individual> newborns = new List<Individual>();
            Random rnd = new Random();
            int probability;
            //Individual[] offspring;
            while (population.Count + newborns.Count < PopulationSize) {
                probability = rnd.Next(0, 2*BestFitness+1);
                indexA = rnd.Next(0, population.Count);
                indexB = rnd.Next(0, population.Count);
                while (indexA == indexB) {
                    indexB = rnd.Next(0, population.Count);
                }
                if (probability <= population[indexA].Fitness + population[indexB].Fitness) // im lepiej dostosowane osobniki tym wieksza szansa ze sie skrzyzuja
                {
                    //offspring = recombination(population[indexA], population[indexB]);
                    //old ver 
                    newborns.Add(randomRecombination(population[indexA], population[indexB]));
                    //newborns.Add(offspring[0]);
                    //newborns.Add(offspring[1]);
                }
            }
            for (int i = 0; i < newborns.Count; i++) {
                if (population.Count < PopulationSize)
                {
                    population.Add(newborns[i]);
                }
            }

        }
    }
}
