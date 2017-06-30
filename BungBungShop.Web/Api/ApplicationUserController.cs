using BungBungShop.Web.Infastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BungBungShop.Service;
using BungBungShop.Web.Models;
using AutoMapper;
using BungBungShop.Model.Models;
using System.Web.Script.Serialization;
using BungBungShop.Common;
using BungBungShop.Web.Infastructure.Extensions;
using BungBungShop.Web.App_Start;
using System.Threading.Tasks;

namespace BungBungShop.Web.Api
{
    [RoutePrefix("api/applicationUser")]
    public class ApplicationUserController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;
        private IApplicationGroupService _appGrroupService;
        private IApplicationRoleService _appRoleService;
        public ApplicationUserController(IErrorService errorService,
            ApplicationUserManager userManager,
            IApplicationGroupService appGrroupService,
            IApplicationRoleService appRoleService) : base(errorService)
        {
            this._userManager = userManager;
            this._appGrroupService = appGrroupService;
            this._appRoleService = appRoleService;
        }

        [Route("getlistpaging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request)
        {
            return CreateHttpRespond(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _userManager.Users;
                IEnumerable<ApplicationUserViewModel> modelVM = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(model);

                PaginationSet<ApplicationUserViewModel> pagedSet = new PaginationSet<ApplicationUserViewModel>()
                {
                    TotalCount = modelVM.Count(),
                    Items = modelVM
                };
                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);
                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " is required.");
            }
            var user = _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var applicationuserViewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user.Result);
                var listGroup = _appGrroupService.GetListGroupByUserId(applicationuserViewModel.Id);
                applicationuserViewModel.Groups = Mapper.Map<IEnumerable<ApplicationGroup>, IEnumerable<ApplicationGroupViewModel>>(listGroup);
                return request.CreateResponse(HttpStatusCode.OK, applicationuserViewModel);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(applicationUserViewModel.Email);
                if (userByEmail != null)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Email đã tồn tại");
                }
                var userByUserName = await _userManager.FindByNameAsync(applicationUserViewModel.UserName);
                if (userByUserName != null)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Tên tài khoản đã tồn tại");
                }
                var newAppUser = new ApplicationUser();
                newAppUser.UpdateUser(applicationUserViewModel);
                try
                {
                    newAppUser.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
                    if (result.Succeeded)
                    {
                        var listAppUserGroup = new List<ApplicationUserGroup>();
                        foreach (var group in applicationUserViewModel.Groups)
                        {
                            listAppUserGroup.Add(new ApplicationUserGroup
                            {
                                GroupId = group.ID,
                                UserId = newAppUser.Id
                            });
                            var listRole = _appRoleService.GetListRoleByGroupId(group.ID);
                            foreach (var role in listRole)
                            {
                                await _userManager.RemoveFromRoleAsync(newAppUser.Id, role.Name);
                                await _userManager.AddToRoleAsync(newAppUser.Id, role.Name);
                            }
                        }
                        _appGrroupService.AddUserToGroups(listAppUserGroup, newAppUser.Id);
                        _appGrroupService.Save();
                        return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
                    }
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, ApplicationUserViewModel appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(appUserViewModel.Id);
                try
                {

                    appUser.UpdateUser(appUserViewModel);
                    var result = await _userManager.UpdateAsync(appUser);
                    if (result.Succeeded)
                    {
                        //delete all role into user
                        var listGroup = _appGrroupService.GetListGroupByUserId(appUser.Id);
                        foreach (var group in listGroup)
                        {
                            var listOldRole = _appRoleService.GetListRoleByGroupId(group.ID);
                            foreach (var role in listOldRole)
                            {
                                await _userManager.RemoveFromRoleAsync(appUser.Id, role.Name);
                            }
                        }
                        //add new role into user
                        var listAppUserGroup = new List<ApplicationUserGroup>();
                        foreach (var newGroup in appUserViewModel.Groups)
                        {
                            listAppUserGroup.Add(new ApplicationUserGroup
                            {
                                GroupId = newGroup.ID,
                                UserId = appUser.Id
                            });
                            var listRole = _appRoleService.GetListRoleByGroupId(newGroup.ID);
                            foreach (var newRole in listRole)
                            {
                                //await _userManager.RemoveFromRoleAsync(appUser.Id, role.Name);
                                //await _userManager.RemoveFromRoleAsync(appUser.Id, newRole.Name);
                                await _userManager.AddToRoleAsync(appUser.Id, newRole.Name);
                            }
                        }
                        _appGrroupService.AddUserToGroups(listAppUserGroup, appUser.Id);
                        _appGrroupService.Save();
                        return request.CreateResponse(HttpStatusCode.OK, appUserViewModel);
                    }
                    else
                    {
                        return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
                    }

                }
                catch (NameDuplicatedException dx)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dx.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return request.CreateResponse(HttpStatusCode.OK, id);
            }
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
        }
    }
}
