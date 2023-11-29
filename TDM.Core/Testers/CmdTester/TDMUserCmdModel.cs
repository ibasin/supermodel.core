using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Supermodel.DataAnnotations.Attributes;
using Supermodel.Presentation.Cmd.Models;
using Supermodel.ReflectionMapper;
using WMDomain.Entities;

namespace CmdTester
{
    public enum GenderEnum { Male, Female }
    
    public class TDMUserCmdModel : CmdModelForEntity<TDMUser>
    {
        #region Overrides
        protected override string LabelInternal => $"{FirstName} {LastName}";
        public override Task<T> MapToCustomAsync<T>(T other)
        {
            var user = CastToEntity(other);
            if (!string.IsNullOrEmpty(NewPassword.Value)) user.Password = NewPassword.Value;
            return base.MapToCustomAsync(other);
        }
        #endregion

        #region Properties
        [Required] public TextBoxCmdModel FirstName { get; set; } = new();
        [Required] public TextBoxCmdModel LastName { get; set; } = new();
        [Email, Required] public TextBoxCmdModel Username { get; set; } = new();
        
        [Required, NotRMapped] public DateCmdModel DOB { get; set; } = new() { DateTimeValue = DateTime.Today };
        [NotRMapped] public CheckboxCmdModel Admin {get; set; } = new();
        [Required, NotRMapped] public DropdownCmdModelUsingEnum<GenderEnum> Sex { get; set; } = new();

        [SkipForDisplay, ForceRequiredLabel, NotRMapped, MustEqualTo(nameof(ConfirmPassword), ErrorMessage = "Passwords do not match")]
        public PasswordTextBoxCmdModel NewPassword { get; set; } = new();

        [SkipForDisplay, ForceRequiredLabel, NotRMapped, MustEqualTo(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
        public PasswordTextBoxCmdModel ConfirmPassword { get; set; } = new();
        #endregion
    }
}