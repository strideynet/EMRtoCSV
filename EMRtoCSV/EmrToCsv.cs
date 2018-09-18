using System;
using System.IO;
using Seca.EmrContract;
using Seca.EmrContract.Measurements;

namespace EMRtoCSV
{
    [EmrModule("EMRtoCSV", "Sends measurements to a CSV file | Noah Stride | RC3", null)]
    public class EMRtoCSV: Seca.EmrContract.Module
    {
        private string path = @"c:\secadata\data.csv";
        
        public override void SendMeasurement(IMeasurement measurement)
        {
            string height = measurement.HeightMeasurement.ToString(".", LengthUnit.Meter);
            string weight = measurement.WeightMeasurement.ToString(".", MassUnit.Kilograms);

            height = height.Split(' ')[0];
            weight = weight.Split(' ')[0];

            string time = DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            
            
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine(time + "," + weight + "," + height);
            }

        }
    }
}