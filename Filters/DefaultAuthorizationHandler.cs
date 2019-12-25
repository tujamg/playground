namespace AuthPlayGround.Filters
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class DefaultAuthorizationHandler : DelegatingHandler
    {
        public DefaultAuthorizationHandler(string logger)
        {
            Console.WriteLine($"Inside DefaultAuth: {logger}");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //if (request.Method == HttpMethod.Post && request.Content != null)
            //{
            //    var body = await request.Content.ReadAsStringAsync();
            //    request.Properties[CCMConstants.CCMPostBody] = body;
            //}

            //var response = await base.SendAsync(request, cancellationToken);

            //var metricLabel = RequestHelper.GenerateAuthorizationMetricLabel(request);
            //if (!string.IsNullOrEmpty(metricLabel))
            //{
            //    this._logger.PushMetric(metricLabel);
            //    this._logger.TraceInfo(metricLabel);
            //}

            //return response;
            throw new NotImplementedException();
        }
    }
}
