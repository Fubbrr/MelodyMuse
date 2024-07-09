using Microsoft.AspNetCore.Mvc;

namespace MelodyMuse.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("test")]
        //���ڲ��ԣ���test.TEST()��Ӧ
        public IActionResult GetNewData()
        {
            try
            {
                //���ݿ��ѯ���
                string sql = "select * from c##main_schema.artist";

                //���ú�����ѯ�õ������
                List<Dictionary<string, object>> table = DatabaseOperation.Select(sql);
                string result = "";

                //ѭ����ȡÿһ��
                foreach (var item in table)
                {
                    //ѭ����ȡÿһ��
                    foreach (string key in item.Keys)
                    {
                        result += key + ":" + item[key] + " ";
                    }
                    result += "\n";
                }

                // ��������
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
