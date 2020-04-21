using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class DummyController : Controller
    {
        [HttpPost]
        public DeviceBase PostDevice([FromBody]DeviceBase device)
        {
            switch (device)
            {
                case var _ when device is CellPhone:
                    //handle new cellphone
                    return device;

                case var _ when device is Laptop:
                    //handle new laptop
                    return device;

                default:
                    return null;
            }
        }

        [HttpGet]
        public string GetDeviceString()
        {
            var serializationSettings = new JsonSerializerSettings();
            serializationSettings.TypeNameHandling = TypeNameHandling.All;

            var device = new Laptop
            {
                Name = "MSI 123",
                IsGaming = true
            };

            return JsonConvert.SerializeObject(device, serializationSettings);
        }
    }
}
