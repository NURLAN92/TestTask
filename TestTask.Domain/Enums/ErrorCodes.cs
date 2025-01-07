using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Enums
{
    public enum ErrorCodes
    {
        [Description("Invalid username or password.")]
        NAME_OR_PASSWORD_IS_NOT_CORRECT = 1_0_0,

        [Description("User already exists.")]
        USER_ALREADY_EXISTS = 1_1_0,

        [Description("Data not found.")]
        DATA_NOT_FOUND = 2_1_1,

        [Description("This data is already exist.")]
        DATA_IS_ALREADY_EXIST = 2_1_2,

        [Description("There are some validations error.")]
        VALIDATION_ERROR = 3_0_0,

        [Description("Invalid EMAIL OR PASSWORD.")]
        EMAIL_OR_PASSWORD_IS_NOT_CORRECT
    }
}
