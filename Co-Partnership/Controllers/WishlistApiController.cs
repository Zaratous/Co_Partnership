﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Co_Partnership.Models;
using Co_Partnership.Services;
using Co_Partnership.Models.Database;



namespace Co_Partnership.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Wishlist")]
    public class WishlistApiController : Controller
    {

        // We use the usermanager information for the user
        private UserManager<ApplicationUser> manager;

        private IWishRepository wishRepository;

        private IUserRepository userep;

        // Constructor for the controller
        public WishlistApiController(UserManager<ApplicationUser> mngr, IWishRepository wRpstr, IUserRepository us)
        {
            manager = mngr;
            wishRepository = wRpstr;
            userep = us;
        }


        // This function gets the user Id
        public async Task<int> GetUserId()
        {
            var user = await manager.FindByNameAsync(HttpContext.User.Identity.Name);
            return userep.Users.FirstOrDefault(a => a.ExtId == user.Id).Id;
        } 



        // This function gets all the objects from the wishlist for this user
        // GET: api/ProductsApi
        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            int BId = await GetUserId();

            return wishRepository.Wishes.Where(a => a.UserId == BId);
        }


        // This function checks if the item is already in the wishlist and returns it, gets as input the item id and cross checks with the user
        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        public async Task<Object> Get(int itemid)
        {
            int userid = await GetUserId();
            return wishRepository.Wishes.FirstOrDefault(a => a.ItemId==itemid  && a.UserId == userid);
        }
        

        // This one creates a new wishlist item from a selection 
        // POST: api/ProductsApi
        [HttpPost]
        public async void Post([FromBody]WishList wish)
        {
            int userid = await GetUserId();
            wish.UserId = userid;
            wishRepository.SaveWish(wish);
        }

        // This one deletes the list item based on the item id and current user
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            int userid = await GetUserId();
            wishRepository.DeleteWish(id,userid);

        }
    }
}
