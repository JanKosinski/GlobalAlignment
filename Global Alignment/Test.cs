using Global_Alignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

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

    public string runTest(int _populationSize, List<string> _seqToAlign, int _probOfMutations, int _numOfIterations, int _repeats, int _errors)
    {
        GeneticAlgorithm genAlg;
        Random rnd;
        int mut;
        int prvBestAligment;
        int BestFitnessUpToDate;
        string result = String.Format("Population Size: {0}; Sequences Aligned {1}; Probability of Mutations {2}; Number of Iterations: {3}; Number of Errors: {4}", _populationSize, _seqToAlign.Count, _probOfMutations, _numOfIterations, _errors) + Environment.NewLine;
        for (int rep = 0; rep < _repeats; rep++)
        {
            BestFitnessUpToDate = 0;
            result += "Repeat" + rep.ToString() + "\t";
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            genAlg = new GeneticAlgorithm(_populationSize, _seqToAlign, _probOfMutations);
            genAlg.createRandomPopulation();
            rnd = new Random();
            prvBestAligment = 0;
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
                genAlg.convertBoolToAlignment();
                genAlg.fitnessFunction();
                if (genAlg.BestAlignment.Fitness > BestFitnessUpToDate)
                {
                    BestFitnessUpToDate = genAlg.BestAlignment.Fitness;
                }
                if (i % 100 == 0 || i == 0)
                {
                    result += BestFitnessUpToDate + "\t";
                }
            }
            result += Environment.NewLine;
            /*
            Console.WriteLine(genAlg.BestAlignment.Fitness.ToString());
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(Convert.ToDouble(elapsedMs)/1000.0);
            Console.WriteLine("___________________________");
            */
        }
        return result;
    }

    public void run()
    {
        string result = "";
        List<string> sequences;
        int errors = 0;
        int numberOfSequencesToAlign = 3;
        int seqLen = 50;
        int populationSize = 100;
        int probabilityOfMutations = 3;
        int iterations = 10000;
        int repeats = 12;
        sequences = generateRandomSequences(numberOfSequencesToAlign, seqLen, errors);
        result = runTest(populationSize, sequences, probabilityOfMutations, iterations, repeats, errors);

        OpenFileDialog ofd = new OpenFileDialog();  // wybieramy lokalizacje pliku
        ofd.CheckFileExists = false;
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            string path = ofd.FileName;
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.WriteLine(result);  // zapisujemy do pliku
            file.Close();
            
        }
    }
}
