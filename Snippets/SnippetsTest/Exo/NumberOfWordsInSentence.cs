using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Exo
{
    [TestFixture]
    class NumberOfWordsInSentence
    {
        [Test]
        public void Test()
        {
            var sentence = "a aa b ccc test ccc c aa a aa";

            // LINQ
            {
                var ordered = sentence.Split()
                    .GroupBy(x => x).Select(x => new { Word = x.Key, Occurence = x.Count() })
                    .OrderByDescending(x => x.Occurence).ThenBy(x => x.Word);
            }

            // Imperative
            {
                var dicoCount = new Dictionary<string, int>();
                foreach (var word in sentence.Split())
                {
                    int count;
                    if (dicoCount.TryGetValue(word, out count))
                        dicoCount[word]++;
                    else
                        dicoCount[word] = 1;
                }

                var list = dicoCount.ToList();
                list.Sort((a, b) => -a.Value.CompareTo(b.Value) * 2 + a.Key.CompareTo(b.Key));
            }

            // Imperative 2
            {
                var dico = new Dictionary<string, int>();

                foreach (var word in sentence.Split())
                {
                    int count;
                    if (dico.TryGetValue(word, out count))
                        dico[word]++;
                    else
                        dico[word] = 1;
                }

                var sortedDico = new SortedSet<DicoWrapper>(new DicoWrapper());
                foreach (var item in dico)
                    sortedDico.Add(new DicoWrapper() { Occurence = item.Value, Word = item.Key });
            }
        }

        class DicoWrapper : IComparer<DicoWrapper>
        {
            public string Word { get; set; }
            public int Occurence { get; set; }

            public int Compare(DicoWrapper a, DicoWrapper b)
            {
                return -a.Occurence.CompareTo(b.Occurence) * 2 + a.Word.CompareTo(b.Word);
            }
        }
    }
}
