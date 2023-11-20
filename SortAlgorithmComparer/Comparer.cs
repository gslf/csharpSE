using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithmComparer {
    internal static class Comparer {
        public static List<string> GenerateTestList(int size) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringBuilder = new StringBuilder();
            var random = new Random();

            List<string> newList = new List<string>();

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < 10; j++) {
                    stringBuilder.Append(chars[random.Next(chars.Length)]);
                }
                newList.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }

            return newList;

        }
    }
}
