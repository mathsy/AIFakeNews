using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace AIFakeNews
{
    public class TopicData
    {
        [LoadColumn(0)]
        public string Text1 { get; set; }
        [LoadColumn(1)]
        public string Text2 { get; set; }
        [LoadColumn(2)]
        public float Similiarity { get; set; }


    }
}
