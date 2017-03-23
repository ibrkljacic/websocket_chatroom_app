using Microsoft.Web.WebSockets;
using RZNU_lab2.Models;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RZNU_lab2.Controllers
{
    public class ChatRoomController : ApiController
    {

        public HttpResponseMessage Get(string username)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

    }
}