using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LearningProject
{
    class SCIFIPolDataImporter
    {
        public List<RecordTwo> GetData(string path)
        {
            string pattern = @"(?<hour>\d\d)\.(?<minute>\d\d)\t(?<title>.*:|.*):?\s(?<subtitle>.*?)(\s|(?=\())\n.*?(((Sezon (?<sezon>\d+)), (Odcinek (?<odcinek>\d+))(.*?)wyk\.:\s(?<actors>\D*?)(?=\().+\n(?<text>.*?)(?=\()))";
            string alternativePattern = @"((?<hour>\d\d)\.(?<minute>\d\d)\t(?<title>.*?)(\s|(?=\())\n.*?(wyk\.:\s(?<actors>\D*?)(?=\().+\n(?<text>.*?)(?=\()))";
            string schedule = File.ReadAllText(path, System.Text.Encoding.UTF8);
            Regex exLine = new Regex($"{pattern}|{alternativePattern}", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);

            List<RecordTwo> recordList = new List<RecordTwo>();
            MatchCollection matches = exLine.Matches(schedule);
            int day = 1;
            foreach (Match match in matches)
            {

                RecordTwo recordTwo = new RecordTwo();

                recordTwo.BroadcastDateAndTime = DateTime.Parse($"{day}.09.2019 {match.Groups["hour"].Value}:{match.Groups["minute"].Value}");
                if (match.Groups["hour"].Value == "05")
                {
                    day++;
                }

                if (match.Groups["sezon"].Value != "")
                {
                    recordTwo.Sezon = short.Parse(match.Groups["sezon"].Value);
                }
                if (match.Groups["odcinek"].Value != "")
                {
                    recordTwo.Odcinek = short.Parse(match.Groups["odcinek"].Value);
                }
                recordTwo.Title = match.Groups["title"].Value;
                recordTwo.SubTitle = match.Groups["subtitle"].Value;  
                recordTwo.Text = match.Groups["text"].Value;
                recordTwo.Actors = match.Groups["actors"].Value.Split(',').ToList<string>();
                recordList.Add(recordTwo);

            }
            return recordList;
        }

    }
}
