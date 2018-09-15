using System;
using System.IO;
using Seca.EmrContract;
using Seca.EmrContract.Measurements;

namespace EMRtoCSV
{
    [EmrModule("EMRtoCSV", "Sends measurements to a CSV file | Noah Stride | 1.01", null)]
    public class EMRtoCSV: Seca.EmrContract.Module
    {
        private string path = @"c:\secadata\data.csv";
        
        public override void SendMeasurement(IMeasurement measurement)
        {
            string height = measurement.HeightMeasurement.ToString(".", LengthUnit.Meter);
            string weight = measurement.WeightMeasurement.ToString(".", MassUnit.Kilograms);

            string time = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK");
            
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine(time + "," + weight + "," + height);
            }

        }
    }
}