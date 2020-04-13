// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Orchestrator.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.ML;
    using Orchestrator.model;

    [Route("api/[controller]")]
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<SentimentData, SentimentPrediction> _predictionEnginePool;

        public PredictController(PredictionEnginePool<SentimentData, SentimentPrediction> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] SentimentData input)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            SentimentPrediction prediction = _predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", example: input);

            string sentiment = Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative";

            return Ok(sentiment);
        }
    }
}
