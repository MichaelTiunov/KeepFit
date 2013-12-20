using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KeepFit.Controllers
{
    public class BaseController : Controller
    {
        protected static JsonResult JsonNet(object responseBody)
        {
            return new JsonNetResult(responseBody, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public class JsonNetResult : JsonResult
        {
            public JsonNetResult()
            {
            }

            public JsonNetResult(object responseBody)
            {
                ResponseBody = responseBody;
            }

            public JsonNetResult(object responseBody, JsonSerializerSettings settings)
            {
                ResponseBody = responseBody;
                Settings = settings;
            }

            /// <summary>
            /// Gets or sets the serialiser settings.
            /// </summary> 
            public JsonSerializerSettings Settings { get; set; }

            /// <summary>
            /// Gets or sets the body of the response.
            /// </summary> 
            public object ResponseBody { get; set; }

            /// <summary>
            /// Gets the formatting types depending on whether we are in debug mode.
            /// </summary> 
            private Formatting Formatting
            {
                get
                {
                    return Debugger.IsAttached ? Formatting.Indented : Formatting.None;
                }
            }

            /// <summary> 
            /// Serialises the response and writes it out to the response object 
            /// </summary> 
            /// <param name="context">The execution context</param> 
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                HttpResponseBase response = context.HttpContext.Response;

                // set content type 
                if (!String.IsNullOrEmpty(ContentType))
                {
                    response.ContentType = ContentType;
                }
                else
                {
                    response.ContentType = "application/json";
                }

                // set content encoding 
                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }

                if (ResponseBody != null)
                {
                    response.Write(JsonConvert.SerializeObject(ResponseBody, Formatting, Settings));
                }
            }
        }
    }
}
