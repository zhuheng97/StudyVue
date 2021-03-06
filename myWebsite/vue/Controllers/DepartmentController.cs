﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using vue.DBModel;
using vue.IService;
using vue.ViewModel;

namespace vue.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;
        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        /// <summary>
        /// 分页及获取部门列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        [Authorize(Policy = "Department_Get")]
        [HttpPost]
        public ReturnViewModel<PaginationResponeViewModel<IEnumerable<Department>>> GetDepartmentList([FromBody]PaginationRequestViewModel pagination)
        {
            return _department.GetDepartmentList(pagination);
        }


        /// <summary>
        /// 不分页获取部门列表用于表格展示
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ReturnViewModel<IEnumerable<Department>> GetAllDepartments() => _department.GetAllDepartments();


        /// <summary>
        /// 添加一个部门
        /// </summary>
        /// <param name="adepartment"></param>
        /// <returns></returns>
        [Authorize(Policy = "Department_Add")]
        [HttpPost]
        public ReturnViewModel<Department> AddDepartment([FromBody]Department adepartment) => _department.AddDepartment(adepartment);

        /// <summary>
        /// 删除一个部门
        /// </summary>
        /// <param name="adepartment"></param>
        /// <returns></returns>
        [Authorize(Policy = "Department_Del")]
        [HttpPost]
        public ReturnViewModel<Department> DeleteDepartment([FromBody]Department adepartment) => _department.DeleteDepartment(adepartment);

        /// <summary>
        /// 编辑一个部门
        /// </summary>
        /// <param name="adepartment"></param>
        /// <returns></returns>
        [Authorize(Policy = "Department_Set")]
        [HttpPost]
        public ReturnViewModel<Department> EditDepartment([FromBody]Department adepartment) => _department.EditDepartment(adepartment);
    }
}