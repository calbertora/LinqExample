using System;
using System.Collections.Generic;
using System.Linq;
using LinqFaroShuffle;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var times = 0;
            var startingDeck =  (from s in Suits()
                                from r in Ranks()
                                select new { Suit = s, Rank = r }).ToArray();

            var shuffle = startingDeck;
            
            do
            {
                shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26)).ToArray();

                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}
