﻿using DataAccessLayer.DataAccess.ActionDbAccess;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PriceAPI.Controllers.ShopControllers
{
    [Route("api/")]
    [ApiController]
    public class ShopActionsController : ControllerBase
    {
        IActionsDbAccess _actionsDbAccess;

        public ShopActionsController(IActionsDbAccess actionsDbAccess) 
        { 
            _actionsDbAccess = actionsDbAccess;
        }


        [HttpGet("shops/{shopId}/actions")]
        public async Task<JsonResult> GetActions(int shopId)
        {
            List<ActionModel> actionsToReturn = await _actionsDbAccess.GetShopActions(shopId);
            return new JsonResult(actionsToReturn);
        }

        [HttpPost("shops/{shopId}/actions/add")]
        public void AddActions(int shopId, ActionName action_name, [ModelBinder] List<string> action_data)
        {
            _actionsDbAccess.AddShopAction(shopId, action_name, action_data);
        }

        [HttpDelete("shops/{shopId}/actions/delete")]
        public void DeleteAction(int shopId, int actionId)
        {
            _actionsDbAccess.DeleteShopAction(shopId, actionId);
        }

    }
}
