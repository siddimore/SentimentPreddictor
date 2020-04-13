namespace Orchestrator
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.ML;
    using Orchestrator.model;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
            //.FromFile(modelName: "SentimentAnalysisModel", filePath: "MLModels/sentiment_model.zip", watchForChanges: true);

            // Get Model from github
            services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
            .FromUri(
              modelName: "SentimentAnalysisModel",
              uri: "https://github.com/dotnet/samples/raw/master/machine-learning/models/sentimentanalysis/sentiment_model.zip",
              period: TimeSpan.FromMinutes(1));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
