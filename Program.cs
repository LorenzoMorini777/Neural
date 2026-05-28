// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System;



internal class Program{
    const float THRESHOLD = 0.3F;
    const float bias = 0.1F;
    const int domande = 6;
    const float learningRate = 0.1F;
    static float[] weights;
    public static void Main(string[] args){
        Console.WriteLine("start");
        Console.WriteLine("Premi a o p");
        string scelta = Console.ReadLine();
        int[] input = new int[domande];
        weights = LeggiPesi();
        if(scelta == "p")
        {
            
            Console.WriteLine("artista famoso? 1= Si 0 = no");
            input[0]=int.Parse(Console.ReadLine()!)!;
            Console.WriteLine("bel meteo? 1= Si 0 = no");
            input[1]=int.Parse(Console.ReadLine()!)!;
            Console.WriteLine("amici presenti? 1= Si 0 = no");
            input[2]=int.Parse(Console.ReadLine()!)!;
            Console.WriteLine("cibo buono? 1= Si 0 = no");
            input[3]=int.Parse(Console.ReadLine()!)!;
            Console.WriteLine("si puo bere? 1= Si 0 = no");
            input[4]=int.Parse(Console.ReadLine()!)!;
        }
        else
        {
            float sum = bias;
            Allena(); 
            Console.WriteLine("i pesi sono: " + weights[0] + " " + + weights[1] + " " + weights[2] + " " + weights[3] + " " + weights[4] + + weights[5]);
        }
        int decisione = prevedi(weights, bias, input);
        Console.WriteLine("Dovresti farlo? --> " + decisione.ToString());
    

    }
    public static float[] LeggiPesi()
    {
        return [0.3F,0.1F,0.2F,0.1F,0.1F];
    }
    public static void Allena(){
        int[] input;
        int it = 0;
        using (StreamReader sr = new StreamReader("esempio.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] data = line.Split(" ");
                it = 0;
                input = new int [5];
                int risposta = -1;
                foreach(string c in data)
                {  
                    if(it == 5)
                    {
                        char ch = c[0];
                        if(ch == '0')risposta = 0;
                        else if (ch == '1')risposta= 1;
                    }
                    char ch = c[0];
                    if(ch == '0')input[it] = 0;
                    else if (ch == '1')input[it] = 1;
                    else Console.WriteLine("ERRORE INPUT");
                    it++;
                }
                for (int j = 0; j < domande; j++)
                {
                    sum+= input[j]*weights[j];
                }
                int output = activation(sum);
                int error = risposta-output;
                for(int i = 0; i < input.Length;i++)
                {
                    weights[i]+=learningRate *error *input[i];
                }
                bias+=learningRate*error;
            }
        }
    }

    public static int prevedi(float[] weights, float bias, int[] input) {
        float somma = bias;
        ;
        for (int i = 0; i < input.Length; i++) {
            somma += input[i] * weights[i%(int)weights.Length];
        }
        return activation(somma);
    }
    public static int activation(float x) {
        if (x > THRESHOLD) return 1; 
        else return 0;
    }

    public static void Calcola(){

    }

}