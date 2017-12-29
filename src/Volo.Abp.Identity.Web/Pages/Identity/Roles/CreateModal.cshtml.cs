using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.RazorPages;

namespace Volo.Abp.Identity.Web.Pages.Identity.Roles
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateRoleInfoModel RoleModel { get; set; }

        private readonly IIdentityRoleAppService _identityRoleAppService;

        public CreateModalModel(IIdentityRoleAppService identityRoleAppService)
        {
            _identityRoleAppService = identityRoleAppService;
            RoleModel = new CreateRoleInfoModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<CreateRoleInfoModel, IdentityRoleCreateDto>(RoleModel);
            await _identityRoleAppService.CreateAsync(input);

            return NoContent();
        }
    }
}