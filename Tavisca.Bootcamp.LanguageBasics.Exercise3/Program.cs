using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1 {
    public static class Program {
        static void Main(string[] args) {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected) {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static List<int> findMax(int[] a, List<int> list) {
            int max = -999;
            List<int> newList = new List<int>();
            foreach (var i in list) {
                max = Math.Max(max, a[i]);
            }
            foreach (var i in list) {
                if (a[i] == max) {
                    newList.Add(i);
                }
            }
            return newList;
        }
        public static List<int> findMin(int[] a, List<int> list) {
            int min = 999;
            List<int> newList = new List<int>();
            foreach (var i in list) {
                min = Math.Min(min, a[i]);
            }
            foreach (var i in list) {
                if (a[i] == min) {
                    newList.Add(i);
                }
            }
            return newList;
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans) {
            int[] meals = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++) {
                calories[i] = fat[i] * 9 + carbs[i] * 5 + protein[i] * 5;
            }
            for (int i = 0; i < dietPlans.Length; i++) {
                string dietPlan = dietPlans[i];
                List<int> items = new List<int>();
                for (int j = 0; j < protein.Length; j++) {
                    items.Add(j);
                }
                foreach (char d in dietPlan) {
                    switch (d) {
                        case 'p':
                            items = findMin(protein, items);
                            break;
                        case 'P':
                            items = findMax(protein, items);
                            break;
                        case 'c':
                            items = findMin(carbs, items);
                            break;
                        case 'C':
                            items = findMax(carbs, items);
                            break;
                        case 'f':
                            items = findMin(fat, items);
                            break;
                        case 'F':
                            items = findMax(fat, items);
                            break;
                        case 't':
                            items = findMin(calories, items);
                            break;
                        case 'T':
                            items = findMax(calories, items);
                            break;
                    }
                    if (items.Count == 1) {
                        break;
                    }
                }
                meals[i] = items.First();
            }
            return meals;
        }
    }
}