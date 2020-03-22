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
            var startingDeck =  from s in Suits()
                                from r in Ranks()
                                select new { Suit = s, Rank = r };

            var (top,bottom) = (startingDeck.Take(26),startingDeck.Skip(26));

            var shuffle = top.InterleaveSequenceWith(bottom);
            
            do
            {
                shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));

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
