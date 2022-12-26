using System;
using System.Text.Json;
using Vulcanova.Uonet.Api.Common.Models;
using Xunit;

namespace Vulcanova.Uonet.UnitTests.Api.Common.Models;

public class DateTimeInfoTests
{
    [Fact]
    public void FromDateTime_AnyDateTime_CreatesCorrectDateTimeInfoObject()
    {
        // Arrange
        var dt = new DateTime(2022, 9, 2, 9, 5, 21);

        // Act
        var info = DateTimeInfo.FromDateTime(dt);

        // Assert
        Assert.Equal(1662102321000, info.Timestamp);
        Assert.Equal(dt, info.Date);
        Assert.Equal(dt, info.Time);
        Assert.Equal("02.09.2022", info.DateDisplay);
    }

    [Fact]
    public void Serialize_AnyDateTimeInfoObject_SerializesToCorrectJsonString()
    {
        // Arrange
        var dt = new DateTime(2022, 12, 11, 21, 53, 52);
        var info = DateTimeInfo.FromDateTime(dt);

        // Act
        var str = JsonSerializer.Serialize(info);
        
        // Assert
        Assert.Equal(@"{""Timestamp"":1670792032000,""Date"":""2022-12-11"",""DateDisplay"":""11.12.2022"",""Time"":""21:53:52""}", str);
    }
    
    [Fact]
    public void Deserialize_AnyDateTimeInfoObject_DeserializesToCorrectObject()
    {
        // Arrange
        const string json = @"{
            ""Time"": ""21:53:52"",
            ""Timestamp"": 1670792032509,
            ""Date"": ""2022-12-11"",
            ""DateDisplay"": ""11.12.2022""
        }";

        // Act
        var dtInfo = JsonSerializer.Deserialize<DateTimeInfo>(json);
        
        // Assert
        Assert.Equal(new DateTime(2022, 12, 11), dtInfo.Date);
        Assert.Equal(21, dtInfo.Time.Hour);
        Assert.Equal(53, dtInfo.Time.Minute);
        Assert.Equal(52, dtInfo.Time.Second);
        Assert.Equal("11.12.2022", dtInfo.DateDisplay);
    }
}