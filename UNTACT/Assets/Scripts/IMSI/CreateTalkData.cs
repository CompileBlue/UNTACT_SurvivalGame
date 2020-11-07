using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CreateTalkData : MonoBehaviour
{
    static string path = @"C:/Users/jaeyoung/Github/UNTACT_SurvivalGame/UNTACT/Assets/TalkData/TalkData.txt";

    StreamReader reader;
    string line;

    void Start()
    {
        reader = new StreamReader(path);
    }

    public string ReadText()
    {
        FileInfo fileInfo = new FileInfo(path);
        List<string> textList = new List<string>();

        if (fileInfo.Exists)
        {
            while ((line = reader.ReadLine()) != null)
            {
                textList.Add(line);
                string[] textListToString = textList.ToArray();
            }

            reader.Close();
        }

        return "IMSI";
    }
}
