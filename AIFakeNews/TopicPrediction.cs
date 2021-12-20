﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace AIFakeNews
{
    class TopicPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }

    }
}
