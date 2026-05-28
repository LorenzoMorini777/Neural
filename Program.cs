// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System;



internal class Program{
    const float THRESHOLD = 0.3F;
    const float bias = 0.1F;
    const int domande = 5;

    public static void Main(string[] args){
        Console.WriteLine("start");
        Console.WriteLine("Premi a o p");
        string scelta = Console.ReadLine();
        int[] input;
        if(scelta == "p")
        {
            input = new int[domande];
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
            input = LeggiInput(3); 
        }
        float[] weights = LeggiPesi();
        int decisione = prevedi(weights, bias, input);
        Console.WriteLine("Dovresti farlo? --> " + decisione.ToString());
    }
    public static float[] LeggiPesi()
    {
        return [0.3F,0.1F,0.2F,0.1F,0.1F];
    }
    public static int[] LeggiInput(int lenght){
        int[] input = new int[3];
        int it = 0;
        using (StreamReader sr = new StreamReader("Dati.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] data = line.Split(" ");
                foreach(string c in data)
                {
                    char ch = c[0];
                    if(ch == '0')input[it] = 0;
                    else if (ch == '1')input[it] = 1;
                    else Console.WriteLine("ERRORE INPUT");
                    it++;
                }
            }
        }
        return input;
    }

    public static int prevedi(float[] weights, float bias, int[] input) {
        float somma = bias;
        for (int i = 0; i < weights.Length; i++) {
            somma += input[i] * weights[i];
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