using System;
using Microsoft.ML.Data;

namespace Orchestrator
{
    public class IrisPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
