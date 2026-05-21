// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System;
Console.WriteLine("Hello, World!");



public partial class Program{
    static float THRESHOLD = 0.3F;
    static float bias = 0.0F;

    public static void Main(string[] args){
        Console.WriteLine("start");
        float[] weights = LeggiPesi();
        int bias = 4;
        int[] input = LeggiInput(3);
        int decisione = prevedi(weights, bias, input);
        Console.WriteLine(decisione);
    }
    public static float[] LeggiPesi()
    {
        return [0.5F,0.1F,0.7F];
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