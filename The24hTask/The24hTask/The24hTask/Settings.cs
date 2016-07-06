using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace The24hTask
{
    public static class Settings
    {
        public static void ExtractAndRewrite(string inputPath, string alphaOutputPath, string numerOutputPath)
        {
            var inputStreamReader = new StreamReader(inputPath);
            var alphaStreamWriter = alphaOutputPath;
            var numerStreamWriter = numerOutputPath;

            var resultFromParse = Parse(inputStreamReader);
            RewriteResult(resultFromParse, alphaStreamWriter, numerStreamWriter);
        }

        private static Dictionary<string, List<string>> Parse(StreamReader input)
        {
            var inputInString = input.ReadToEnd().Replace(System.Environment.NewLine, "");
            var splittedInputByLeftSquareBracket = inputInString.Split('[');
            int lastIndexOfData;
            string onlyTheNeccessaryDataAsString;
            string[] groupsWithItems;
            int itemsFirstIndex;
            string itemsAsString;
            string[] itemsInArray;
            List<string> itemsInList;
            var listWithGroups = new List<string>();
            var result = new List<string>();
            var dictionaryWithResult = new Dictionary<string, List<string>>();
            var nameOfGroup = "";
            foreach (var splittedItem in splittedInputByLeftSquareBracket)
            {
                lastIndexOfData = splittedItem.IndexOf(']');
                if (lastIndexOfData == -1)
                {
                    continue;
                }
                //Getting rid of the unnecessary data
                onlyTheNeccessaryDataAsString = splittedItem.Substring(0, lastIndexOfData);
                //Getting rid of more unnecessary data
                groupsWithItems = onlyTheNeccessaryDataAsString.Split(')');
                foreach (var group in groupsWithItems)
                {
                    itemsFirstIndex = group.IndexOf('(');
                    //if it is -1 there is no or wrong data -- skip the iteration 
                    if (itemsFirstIndex == -1)
                    {
                        continue;
                    }
                    nameOfGroup = group.Substring(0, itemsFirstIndex);
                    itemsAsString = group.Substring(itemsFirstIndex + 1);
                    itemsInArray = itemsAsString.Split('\\');

                    itemsInList = new List<string>();
                    foreach (var item in itemsInArray)
                    {
                        if (itemsInList.Contains(item))
                        {
                            continue;
                        }
                        itemsInList.Add(item);
                    }

                    //Adding the groups and items in the dictionary
                    if (dictionaryWithResult.ContainsKey(nameOfGroup))
                    {

                        //Adding the unique values if the group exists
                        foreach (var item in itemsInList)
                        {
                            if (dictionaryWithResult[nameOfGroup].Contains(item))
                            {
                                continue;
                            }
                            dictionaryWithResult[nameOfGroup].Add(item);
                        }
                    }
                    else
                    {
                        dictionaryWithResult.Add(nameOfGroup, itemsInList);
                    }
                }
            }
            return dictionaryWithResult;
        }

        private static void RewriteResult(Dictionary<string, List<string>> result, string alphaOutputPath, string numerOutputPath)
        {
            var orderedResult = new Dictionary<string, List<string>>();
            var sortedList = result.Keys.OrderBy(x => x);
            var omg = result.SelectMany(x => x.Value);
            File.Create(numerOutputPath).Close();
            File.Create(alphaOutputPath).Close();
            foreach (var item in sortedList)
            {
                orderedResult.Add(item, result[item]);
            }
            List<string> alphaList;
            List<int> numericList;
            string groupName;
            int number;
            bool isNumeric;

            foreach (var group in orderedResult)
            {
                groupName = group.Key;
                alphaList = new List<string>();
                numericList = new List<int>();
                //Organiseing the values
                foreach (var item in group.Value)
                {
                    isNumeric = int.TryParse(item, out number);
                    if (isNumeric)
                    {
                        numericList.Add(number);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(item))
                        {
                            continue;
                        }
                        alphaList.Add(item);
                    }
                }
                //sorting the data
                alphaList.Sort();
                numericList.Sort();


                //Adding groups and items in the alpha file
                using (var alphaWriter = new StreamWriter(alphaOutputPath, true))
                {

                    alphaWriter.WriteLine(groupName);
                    foreach (var item in alphaList)
                    {
                        alphaWriter.WriteLine(" " + item);
                    }
                    alphaWriter.WriteLine();

                }


                //Adding groups and items in the numeric file
                using (var numericWriter = new StreamWriter(numerOutputPath, true))
                {

                    numericWriter.WriteLine(groupName);
                    foreach (var item in numericList)
                    {
                        numericWriter.WriteLine(" " + item);
                    }
                    numericWriter.WriteLine();
                }

            }
        }


    }
}
