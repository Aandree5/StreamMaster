using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StreamMaster.Application.Statistics.Queries;

namespace StreamMaster.Application.Statistics.Controllers
{
    [Authorize]
    public partial class StatisticsController(ILogger<StatisticsController> _logger) : ApiControllerBase, IStatisticsController
    {
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ChannelMetric>>> GetChannelMetrics()
        {
            try
            {
            var ret = await Sender.Send(new GetChannelMetricsRequest()).ConfigureAwait(false);
             return ret.IsError ? Problem(detail: "An unexpected error occurred retrieving GetChannelMetrics.", statusCode: 500) : Ok(ret.Data?? []);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request to get GetChannelMetrics.");
                return Problem(detail: "An unexpected error occurred. Please try again later.", statusCode: 500);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<StreamConnectionMetricData>> GetStreamConnectionMetricData([FromQuery] GetStreamConnectionMetricDataRequest request)
        {
            try
            {
            var ret = await Sender.Send(request).ConfigureAwait(false);
             return ret.IsError ? Problem(detail: "An unexpected error occurred retrieving GetStreamConnectionMetricData.", statusCode: 500) : Ok(ret.Data?? new());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request to get GetStreamConnectionMetricData.");
                return Problem(detail: "An unexpected error occurred. Please try again later.", statusCode: 500);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<StreamConnectionMetricData>>> GetStreamConnectionMetricDatas()
        {
            try
            {
            var ret = await Sender.Send(new GetStreamConnectionMetricDatasRequest()).ConfigureAwait(false);
             return ret.IsError ? Problem(detail: "An unexpected error occurred retrieving GetStreamConnectionMetricDatas.", statusCode: 500) : Ok(ret.Data?? []);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request to get GetStreamConnectionMetricDatas.");
                return Problem(detail: "An unexpected error occurred. Please try again later.", statusCode: 500);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<VideoInfo>> GetVideoInfo([FromQuery] GetVideoInfoRequest request)
        {
            try
            {
            var ret = await Sender.Send(request).ConfigureAwait(false);
             return ret.IsError ? Problem(detail: "An unexpected error occurred retrieving GetVideoInfo.", statusCode: 500) : Ok(ret.Data?? new());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request to get GetVideoInfo.");
                return Problem(detail: "An unexpected error occurred. Please try again later.", statusCode: 500);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<VideoInfoDto>>> GetVideoInfos()
        {
            try
            {
            var ret = await Sender.Send(new GetVideoInfosRequest()).ConfigureAwait(false);
             return ret.IsError ? Problem(detail: "An unexpected error occurred retrieving GetVideoInfos.", statusCode: 500) : Ok(ret.Data?? []);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request to get GetVideoInfos.");
                return Problem(detail: "An unexpected error occurred. Please try again later.", statusCode: 500);
            }
        }
    }
}

namespace StreamMaster.Application.Hubs
{
    public partial class StreamMasterHub : IStatisticsHub
    {
        public async Task<List<ChannelMetric>> GetChannelMetrics()
        {
             var ret = await Sender.Send(new GetChannelMetricsRequest()).ConfigureAwait(false);
            return ret.Data?? [];
        }
        public async Task<StreamConnectionMetricData> GetStreamConnectionMetricData(GetStreamConnectionMetricDataRequest request)
        {
             var ret = await Sender.Send(request).ConfigureAwait(false);
            return ret.Data?? new();
        }
        public async Task<List<StreamConnectionMetricData>> GetStreamConnectionMetricDatas()
        {
             var ret = await Sender.Send(new GetStreamConnectionMetricDatasRequest()).ConfigureAwait(false);
            return ret.Data?? [];
        }
        public async Task<VideoInfo> GetVideoInfo(GetVideoInfoRequest request)
        {
             var ret = await Sender.Send(request).ConfigureAwait(false);
            return ret.Data?? new();
        }
        public async Task<List<VideoInfoDto>> GetVideoInfos()
        {
             var ret = await Sender.Send(new GetVideoInfosRequest()).ConfigureAwait(false);
            return ret.Data?? [];
        }
    }
}
