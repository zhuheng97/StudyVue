﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vue.DBModel;
using vue.IService;
using vue.ViewModel;
using codes = ViewModel.StateCodes.StateCode;

namespace vue.Controllers
{
    /// <summary>
    /// 请假表
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaveController : Controller
    {
        private readonly ILeave _leave;
        public LeaveController(ILeave leave)
        {
            this._leave = leave;
        }

        [HttpGet]
        [Authorize(Policy = "CEO")]
        public ReturnViewModel<List<Leave>> GetLeaves()
        {
            return new ReturnViewModel<List<Leave>>()
            {
                code = (int)codes.Success,
                data = _leave.GetLeave(),
            };
        }

        [HttpPost]
        public ReturnViewModel<List<signinModel>> GetSignInInfo()
        {
            List<signinModel> data = new List<signinModel>()
            {
                new signinModel{ Date=DateTime.Now.AddDays(-7) , SignInType=1},
                new signinModel{ Date=DateTime.Now.AddDays(-6) , SignInType=1},
                new signinModel{ Date=DateTime.Now.AddDays(-5) , SignInType=1},
                new signinModel{ Date=DateTime.Now.AddDays(-4), SignInType=1},
                new signinModel{ Date=DateTime.Now.AddDays(-3) , SignInType=1},
                new signinModel{ Date=DateTime.Now.AddDays(-2) , SignInType=2},
                new signinModel{ Date=DateTime.Now.AddDays(-1) , SignInType=1},
                new signinModel{ Date=DateTime.Now , SignInType=4},
            };
            return new ReturnViewModel<List<signinModel>>()
            {
                code = (int)codes.Success,
                data = data
            };
        }

        public class signinModel
        {
            public DateTime Date { get; set; }
            public int SignInType { get; set; }
        }


    }
}