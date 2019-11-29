using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LearningProject
{
    class LoveNatureDataImporter
    {
        public static List<Record> GetData(string path)
        {
            string schedule = File.ReadAllText(path);
            Regex exLine = new Regex(@"\t");
            var scheduleTable = exLine.Split(schedule);
            List<Record> recordList = new List<Record>();
            for (int i = 1; i < scheduleTable.Length; i += 14)
            {
                Record record = new Record();
                record.BroadcastDateAndTime = DateTime.Parse($"{scheduleTable[i]} {scheduleTable[i + 1]}");
                record.SeriesTitle = scheduleTable[i + 2];
                record.EpisodeTitle = scheduleTable[i + 4];
                record.EpisodeNumber = short.Parse(scheduleTable[i + 7]);
                record.Year = scheduleTable[i + 8];
                record.Synopsis = scheduleTable[i + 10];
                recordList.Add(record);
            }
            return recordList;
        }
    }
}
