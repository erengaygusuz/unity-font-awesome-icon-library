using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FontAwesomeIconCodeGenerator : MonoBehaviour
{
    private string regularFilePath = @"C:\Users\User\Desktop\regular.txt";
    private Dictionary<string, string> namesWithUtf16CodesRegular = new Dictionary<string, string>();
    private string outRegularFilePath = @"C:\Users\User\Desktop\regular-utf16codes.txt";

    private string solidFilePath = @"C:\Users\User\Desktop\solid.txt";
    private Dictionary<string, string> namesWithUtf16CodesSolid = new Dictionary<string, string>();
    private string outSolidFilePath = @"C:\Users\User\Desktop\solid-utf16codes.txt";

    private string brandsFilePath = @"C:\Users\User\Desktop\brands.txt";
    private Dictionary<string, string> namesWithUtf16CodesBrands = new Dictionary<string, string>();
    private string outBrandsFilePath = @"C:\Users\User\Desktop\brands-utf16codes.txt";

    private void Start()
    {
        TakeValuesFromFile(namesWithUtf16CodesRegular, regularFilePath);
        TakeValuesFromFile(namesWithUtf16CodesSolid, solidFilePath);
        TakeValuesFromFile(namesWithUtf16CodesBrands, brandsFilePath);

        PrintValues(namesWithUtf16CodesRegular);
        PrintValues(namesWithUtf16CodesSolid);
        PrintValues(namesWithUtf16CodesBrands);

        WriteValuesToFile(namesWithUtf16CodesRegular, outRegularFilePath);
        WriteValuesToFile(namesWithUtf16CodesSolid, outSolidFilePath);
        WriteValuesToFile(namesWithUtf16CodesBrands, outBrandsFilePath);
    }

    private void TakeValuesFromFile(Dictionary<string, string> namesWithUtf16Codes, string path)
    {
        StreamReader reader = new StreamReader(path);

        string line;

        while ((line = reader.ReadLine()) != null)
        {
            namesWithUtf16Codes.Add(line.Split('\t')[2], line.Split('\t')[1]);
        }
    }

    private void PrintValues(Dictionary<string, string> namesWithUtf16Codes)
    {
        int i = 0;

        foreach (KeyValuePair<string, string> nameWithUtf16Code in namesWithUtf16Codes)
        {
            Debug.Log(i.ToString() + " Utf16 Code: " + nameWithUtf16Code.Key + ", Name: " + nameWithUtf16Code.Value);
            i++;
        }
    }

    private void WriteValuesToFile(Dictionary<string, string> namesWithUtf16Codes, string path)
    {
        StreamWriter writer = new StreamWriter(path);

        int i = 0;

        foreach (KeyValuePair<string, string> nameWithUtf16Code in namesWithUtf16Codes)
        {
            writer.Write(nameWithUtf16Code.Key);

            if ((namesWithUtf16Codes.Count - 1) != i)
            {
                writer.Write(",");
            }

            i++;
        }

        writer.Close();
    }
}