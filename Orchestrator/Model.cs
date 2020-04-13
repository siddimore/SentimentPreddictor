//using System;
//using System.Threading.Tasks;
//using Microsoft.ML;
//using Microsoft.ML.Data;
//using Microsoft.ML.Runtime;
//using Microsoft.ML.Trainers;
//using Microsoft.ML.Transforms;
//using Microsoft.ML.Models;
//using System;
//using System.Threading.Tasks;
//using Orchestrator.model;

//namespace Orchestrator
//{
//    class Model
//    {

//        public static async Task<PredictionEngineBase<IrisData, IrisPrediction>> Train(LearningPipelineExtensions pipeline, string dataPath, string modelPath)
//        {
//            // Load Data
//            pipeline.Add(new TextLoader(dataPath).CreateFrom<IrisData>(separator: ','));

//            // Transform Data
//            // Assign numeric values to text in the "Label" column, because 
//            // only numbers can be processed during model training   
//            pipeline.Add(new Dictionarizer("Label"));

//            // Vectorize Features
//            pipeline.Add(new ColumnConcatenator("Features", "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));

//            // Add Learner
//            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

//            // Convert Label back to text 
//            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

//            // Train Model
//            var model = pipeline.Train<IrisData, IrisPrediction>();

//            // Persist Model
//            await model.WriteAsync(modelPath);

//            return model;
//        }
//    }
//}
