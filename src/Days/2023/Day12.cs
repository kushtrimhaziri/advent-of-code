using CSharpStarterPack.PuzzleInputs;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CSharpStarterPack.Days_2023
{
    // Day 7 experimental
    public static class Day12
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(12, 2023);

        public static int PuzzleA()
        {
            List<CardTypeEnum> list = new List<CardTypeEnum>();

            var dict = new Dictionary<CardTypeEnum, List<(string, int)>>()
            {
                { CardTypeEnum.FiveOfAKind,new List<(string,int)>() },
                { CardTypeEnum.FourOfAKind,new List<(string,int)>() },
                { CardTypeEnum.FullHouse,new List<(string,int)>() },
                { CardTypeEnum.ThreeOfAKind,new List<(string,int)>() },
                { CardTypeEnum.TwoPair,new List<(string,int)>() },
                { CardTypeEnum.OnePair,new List<(string,int)>() },
                { CardTypeEnum.HighCard,new List<(string,int)>() },

            };
            foreach (var input in Input)
            {
                var splittedInput = input.Split(' ');
                var cardType = FindCardType(input.Split(' ')[0]);

                dict[cardType].Add((splittedInput[0], int.Parse(splittedInput[1])));
            }

            var counter = 1;
            var sum = 0;
            foreach (var item in dict)
            {
                item.Value.Sort();

                foreach (var collectionItem in item.Value)
                {
                    sum += collectionItem.Item2 * counter;
                counter++;
                }

            }
            var ttt = sum;
            return 0;
        }
        public static int PuzzleB()
        {
            return 0;
        }
        private static CardTypeEnum FindCardType(string cards)
        {

            if (cards.All(x => x == cards[0]))
            {
                return CardTypeEnum.FiveOfAKind;
            }

            var dict = new Dictionary<char, int>();

            foreach (var card in cards)
            {
                if (!dict.ContainsKey(card))
                {
                    dict.Add(card, 1);
                }
                else
                {
                    dict[card]++;
                }

            }
            if (dict.Any(x => x.Value == 4)) return CardTypeEnum.FourOfAKind;
            else if (dict.Any(x => x.Value == 3) && dict.Any(x => x.Value == 2)) return CardTypeEnum.FullHouse;
            else if (dict.Any(x => x.Value == 3)) return CardTypeEnum.ThreeOfAKind;
            else if (dict.Where(x => x.Value == 2).Count() == 2) return CardTypeEnum.TwoPair;
            else if (dict.Any(x => x.Value == 2)) return CardTypeEnum.OnePair;
            else return CardTypeEnum.HighCard;
        }

        public enum CardTypeEnum
        {
            FiveOfAKind,
            FourOfAKind,
            FullHouse,
            ThreeOfAKind,
            TwoPair,
            OnePair,
            HighCard
        }
    }
}