using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using baseApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace baseApi.Controllers
{
    public class ItemsController : ApiController
    {
        ItemsModel[] items = new ItemsModel[]
            {
                new ItemsModel(1001, "Burrito", "Vegan", 2.56, "https://upload.wikimedia.org/wikipedia/commons/a/ad/Hippie_Kitchen%2C_Jefferson_Highway%2C_Old_Jefferson_Louisiana_Burrito_Unwrapped.jpg"),
                new ItemsModel(1002, "Chicharrón", "Pork", 1.25, "https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/ChicharronMixto.JPG/375px-ChicharronMixto.JPG"),
                new ItemsModel(1003, "Taco", "Vegan, Chicken, Pork, Beef", 1.00, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/001_Tacos_de_carnitas%2C_carne_asada_y_al_pastor.jpg/330px-001_Tacos_de_carnitas%2C_carne_asada_y_al_pastor.jpg"),
                new ItemsModel(1004, "Nachos", "Fried", 0.25,  "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/Goettanachos.jpg/330px-Goettanachos.jpg"),
                new ItemsModel(1005, "Huarache", "Vegan, Beef", 3.00, "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/Huarache_de_pollo_en_salsa_roja.JPG/375px-Huarache_de_pollo_en_salsa_roja.JPG")
            };
        // connector for fetching data from facets-sqlserver



        public IEnumerable<ItemsModel> GetAllFoods()
        {
            return items;
        }



        public IHttpActionResult GetFood(int id)
        {
            var food = items.FirstOrDefault((p) => p.ItemId == id);
            if (food == null)
            {
                return NotFound();
            }


            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(signingCredentials);

            var payload = new JwtPayload
            {
                {"iss", "a5fgde64-e84d-485a-be51-56e293d09a69"},
                {"scope", "https://example.com/ws"},
                {"aud", "https://example.com/oauth2/v1"},
                {"iat", now},
            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);

            return Ok(tokenString);
        }

    }
}
