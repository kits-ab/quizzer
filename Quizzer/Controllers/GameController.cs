using System;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace Quizzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet("{gameId}/Join")]
        public IActionResult Join(Guid gameId)
        {
            var generator = new PayloadGenerator.Url($"{Request.Scheme}://{Request.Host}{Request.PathBase}/client/{gameId}");
            var payload = generator.ToString();

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new SvgQRCode(qrCodeData);
            var qrCodeAsSvg = qrCode.GetGraphic(5);

            return Content(qrCodeAsSvg, "image/svg+xml; charset=utf-8");
        }
    }
}
