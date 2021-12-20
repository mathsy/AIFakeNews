using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIFakeNews
{
   class TopicalAI
    {

        public static void start_AI(bool train = false)
        {
            var context = new MLContext();
            var data = context.Data.LoadFromTextFile<TopicData>("data/topicdata.csv", hasHeader: true, separatorChar: ';');
            if (train)
            {
                var pipeline = context.Transforms.Expression("Label", "(x) => x== 1 ? true : false", "Similiarity")
                    .Append(context.Transforms.Text.FeaturizeText("Features", nameof(TopicData.Text1)))
                    .Append(context.Transforms.Text.FeaturizeText("Features", nameof(TopicData.Text2)))
                    .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression());
                var model = pipeline.Fit(data);
                context.Model.Save(model, data.Schema, "topic_ai.txt");
                var predictionEngine = context.Model.CreatePredictionEngine<TopicData, TopicPrediction>(model);
                var prediction = predictionEngine.Predict(new TopicData { Text1 = "Flat earth is definitley true.", Text2 = "As we can see, flat earth is true!" });
                Console.WriteLine(prediction.Prediction + " " + prediction.Probability);
                
            }
            if(!train)
            {
                DataViewSchema modelSchema;
                var model = context.Model.Load("topic_ai.txt", out modelSchema);
                var predictionEngine = context.Model.CreatePredictionEngine<TopicData, TopicPrediction>(model);
                foreach(string l in System.IO.File.ReadAllLines("data/topicdata.csv"))
                {
                    var prediction = predictionEngine.Predict(new TopicData { Text1 = l.Split(';')[0], Text2 = l.Split(';')[1] });
                    Console.WriteLine( l + " " + prediction.Prediction + " " + prediction.Probability);
                }
                
                
                
            }
        }
           

        

    }
}