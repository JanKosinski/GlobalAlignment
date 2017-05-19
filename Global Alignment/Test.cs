using Global_Alignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Test
{
    public List<string> generateRandomSequences(int _numberOfSeq, int _len, int _errors)
    {
        string randomSequence;
        List<string> sequences;
        randomSequence = SharedMethods.randomNucleotideSequence(Convert.ToUInt32(_len) * 2, "dna");
        sequences = InstanceGenerator.createInstance(randomSequence, Convert.ToUInt32(_numberOfSeq), Convert.ToUInt32(_errors), "dna");
        return sequences;
    }

    public void runTest(int _populationSize, List<string> _seqToAlign, int _probOfMutations, int _numOfIterations, int _repeats)
    {
        for (int rep = 0; rep < _repeats; rep++)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            GeneticAlgorithm genAlg = new GeneticAlgorithm(_populationSize, _seqToAlign, _probOfMutations);
            genAlg.createRandomPopulation();
            int mut;
            Random rnd = new Random();
            int prvBestAligment = 0;
            for (int i = 0; i < _numOfIterations; i++)
            {
                genAlg.convertBoolToAlignment();
                if (i > 0)
                {
                    prvBestAligment = genAlg.BestAlignment.Fitness;
                }
                genAlg.fitnessFunction();
                genAlg.selection();
                genAlg.crossover();
                mut = rnd.Next(0, 101);
                if (mut <= genAlg.ProbabilityOfMutations)
                {
                    mut = rnd.Next(0, genAlg.PopulationSize);
                    genAlg.population[mut] = genAlg.mutation(genAlg.population[mut]);
                }
            }
            Console.WriteLine(genAlg.BestAlignment.Fitness.ToString());
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(Convert.ToDouble(elapsedMs)/1000.0);
            Console.WriteLine("___________________________");
        }
    }

    public void run()
    {
        List<string> sequences;
        sequences = generateRandomSequences(3, 50, 5);
        runTest(100, sequences, 3, 100, 2);
    }
}
