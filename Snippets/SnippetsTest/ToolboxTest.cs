using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MyDico = System.Collections.Generic.Dictionary<Solution.Pair, int>;

public class Solution
{
    public static void Main(String[] args)
    {
        var line = MyReadInts(2);
        var N = line[0];
        var K = line[1];
        var heights = MyReadInts(N);
        var nbInputs = MyReadInts(1)[0];

        var dico = GenerateDico(heights, K);

        foreach (var i in Enumerable.Range(0, nbInputs))
        {
            line = MyReadInts(2);
            var l = line[0];
            var r = line[1];
            Console.WriteLine(GetTotalFights(dico, l, r));
        }
    }

    public static List<int> MyReadInts(int nb)
    {
        var res = new List<int>(nb);
        char c;
        int n = 0;
        int tmp;

        do
        {
            tmp = Console.Read();

            //if (tmp == 13)
            //    continue;

            if (tmp == 10)
            {
                res.Add(n);
                return res;
            }

            c = (char)tmp;
            if (c == ' ')
            {
                res.Add(n);
                n = 0;
                continue;
            }
            else
            {
                int x = c - 0x30;
                n = n * 10 + x;
            }
        } while (true);
    }

    public static int GetTotalFights(MyDico dico, int l, int r)
    {
        int res = 0;

        for (int i = l; i < r; ++i)
            res += dico[new Pair(i, r)];

        return res;
    }

    public static MyDico GenerateDico(List<int> heights, int K)
    {
        var res = new Dictionary<Pair, int>();

        for (int l = 0; l < heights.Count - 1; ++l)
        {
            int nbFights = 0;
            for (int r = l + 1; r < heights.Count; ++r)
            {
                if (Math.Abs(heights[l] - heights[r]) <= K)
                    ++nbFights;

                res.Add(new Pair(l, r), nbFights);
            }
        }

        return res;
    }

    public struct Pair : IEquatable<Pair>
    {
        public int Index1;
        public int Index2;

        public Pair(int index1, int index2)
        {
            Index1 = index1;
            Index2 = index2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pair))
                return false;

            return Equals((Pair)obj);
        }

        public bool Equals(Pair other)
        {
            return (Index1 == other.Index1 && Index2 == other.Index2);
        }

        public override int GetHashCode()
        {
            return Index1 ^ Index2;
        }
    }
}