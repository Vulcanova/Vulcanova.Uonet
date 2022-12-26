using System;
using System.Text.Json.Serialization;

namespace Vulcanova.Uonet.Api.Common.Models
{
    public class DateTimeInfo
    {
        public long Timestamp { get; set; }

        [JsonConverter(typeof(HebeDateConverter))]
        public DateTime Date { get; set; }

        public string DateDisplay { get; set; }
        
        [JsonConverter(typeof(HebeTimeConverter))]
        public DateTime Time { get; set; }

        public static DateTimeInfo FromDateTime(DateTime dateTime) =>
            new()
            {
                Timestamp = ((DateTimeOffset) dateTime).ToUnixTimeMilliseconds(),
                Date = dateTime,
                DateDisplay = dateTime.ToString("dd.MM.yyyy"),
                Time = dateTime
            };
    }
}