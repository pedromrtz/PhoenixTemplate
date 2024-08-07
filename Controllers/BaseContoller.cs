using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using MyTalk.Attributes;
using PhoenixTemplate.Models.Accesos;

namespace PhoenixTemplate.Controllers
{
    public class BaseController : Controller
    {

        private readonly ILogger<BaseController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly AccesosContext _accesosContext;

        public BaseController(ILogger<BaseController> logger, IWebHostEnvironment env, IConfiguration configuration, AccesosContext accesosContext)
        {
            _accesosContext = accesosContext;
            _logger = logger;
            _env = env;
            _configuration = configuration;
        }

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    if (!(context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute))))
        //    {
        //        ClaimsPrincipal user = HttpContext.User;
        //        if (user.Identity != null && !user.Identity.IsAuthenticated)
        //        {
        //            ViewBag.Error = "Usuario no autorizado";

        //            if (Request.Headers.XRequestedWith == "XMLHttpRequest")
        //            {
        //                context.Result = Json(new { redirect = true, redirectUrl = Url.Action("Error401", "Home") });
        //            }
        //            else
        //            {
        //                context.Result = RedirectToAction("Error401", "Home");
        //            }
        //        }
        //        else
        //        {
        //            if (context.Result is ViewResult viewResult && !(context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(GeneralPermissionAttribute))))
        //            {
        //                var controllerName = context.RouteData.Values["controller"]?.ToString();
        //                var actionName = context.RouteData.Values["action"]?.ToString();
        //                var idUser = Convert.ToInt32(context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "idUser")?.Value);

        //                if (controllerName != null && actionName != null && !UsuarioTienePermiso(controllerName, actionName, idUser))
        //                {
        //                    ViewBag.Error = "Usuario no tiene permiso";
        //                    if (Request.Headers.XRequestedWith == "XMLHttpRequest")
        //                    {
        //                        context.Result = Json(new { redirect = true, redirectUrl = Url.Action("Error403", "Home") });
        //                    }
        //                    else
        //                    {
        //                        context.Result = RedirectToAction("Error403", "Home");
        //                    }
        //                }
        //                else
        //                {
        //                    var userJson = JsonConvert.SerializeObject(user.Claims.Select(c => new { c.Type, c.Value }));
        //                    viewResult.ViewData["User"] = userJson;
        //                }
        //            }

        //            var id_log = user.Claims.FirstOrDefault(c => c.Type == "id_log")?.Value;

        //            var userJson2 = JsonConvert.SerializeObject(user.Claims.Select(c => new { c.Type, c.Value }));
        //            ViewData["User"] = userJson2;
        //        }

        //    }

        //    base.OnActionExecuted(context);
        //}


        private bool UsuarioTienePermiso(string controllerName, string actionName, int idUser)
        {
            var vistasPermitidas = (from pv in _accesosContext.PermisosVistaUsers
                                    join v in _accesosContext.Vistas on pv.IdVista equals v.IdVista
                                    where pv.Estado == 1
                                          && pv.IdUser == idUser
                                          && v.Controller != null && v.Controller != ""
                                          && v.Vista1 != null && v.Vista1 != ""
                                    select new
                                    {
                                        Controller = v.Controller,
                                        Vista = v.Vista1
                                    }).ToList();

            if (vistasPermitidas == null || vistasPermitidas.Count == 0)
            {
                return false;
            }

            return vistasPermitidas.Any(vp => vp.Controller == controllerName && vp.Vista == actionName);
        }

        public string EncryptData(string textData, string encryptionKey)
        {
            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.BlockSize = 128;

            var passBytes = Encoding.UTF8.GetBytes(encryptionKey);
            var encryptionKeyBytes = new byte[16];
            Array.Copy(passBytes, encryptionKeyBytes, Math.Min(passBytes.Length, encryptionKeyBytes.Length));

            aes.Key = encryptionKeyBytes;
            aes.IV = encryptionKeyBytes;

            using var transform = aes.CreateEncryptor();
            var textDataBytes = Encoding.UTF8.GetBytes(textData);
            return Convert.ToBase64String(transform.TransformFinalBlock(textDataBytes, 0, textDataBytes.Length));
        }

        public string DecryptData(string encryptedText, string encryptionKey)
        {
            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.BlockSize = 128;

            var encryptedTextBytes = Convert.FromBase64String(encryptedText);
            var passBytes = Encoding.UTF8.GetBytes(encryptionKey);
            var encryptionKeyBytes = new byte[16];
            Array.Copy(passBytes, encryptionKeyBytes, Math.Min(passBytes.Length, encryptionKeyBytes.Length));

            aes.Key = encryptionKeyBytes;
            aes.IV = encryptionKeyBytes;

            using var transform = aes.CreateDecryptor();
            var textDataBytes = transform.TransformFinalBlock(encryptedTextBytes, 0, encryptedTextBytes.Length);
            return Encoding.UTF8.GetString(textDataBytes);
        }

    }

}
