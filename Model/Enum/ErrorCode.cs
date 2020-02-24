using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Enum
{
    public enum ErrorCode
    {
        [DisplayAttribute(Description = "Unknown.")]
        U000,

        /******Oauth*******/
        /// <summary>You do not have access.</summary>
        [DisplayAttribute(Description = "You do not have access.")]
        O000,

        /// <summary>You logout.</summary>
        [DisplayAttribute(Description = "You logout.")]
        O001,

        /// <summary>Login Time out.</summary>
        [DisplayAttribute(Description = "Login Time out.")]
        O002,

        /******Permission*******/
        /// <summary>You do not have permission.</summary>
        [DisplayAttribute(Description = "You do not have permission.")]
        P000,

        /******Permission2*******/
        /// <summary>You do not have permission.</summary>
        [DisplayAttribute(Description = "User ไม่มีสิทธิ์ใช้งานส่วนนี้")]
        P001,

        /******Valid*******/
        /// <summary>Please check I'm not a robot.</summary>
        [DisplayAttribute(Description = "Please check I'm not a robot.")]
        V000,

        /// <summary>Duplicate data.</summary>
        [DisplayAttribute(Description = "Duplicate data.")]
        V001,

        /// <summary>Save failed.</summary>
        [DisplayAttribute(Description = "Save failed.")]
        V002,

        /// <summary>Delete failed.</summary>
        [DisplayAttribute(Description = "Delete failed.")]
        V003,

        /// <summary>Email Not Found.</summary>
        [DisplayAttribute(Description = "Email Not Found.")]
        V004,

        /// <summary>Token reset password expire.</summary>
        [DisplayAttribute(Description = "Token reset password expire.")]
        V005,

        /// <summary>Username not found.</summary>
        [DisplayAttribute(Description = "Username not found.")]
        V006,

        /// <summary>Password and Confirm Password not match.</summary>
        [DisplayAttribute(Description = "Password and Confirm Password not match.")]
        V007,

        /// <summary>Old password is incorrect.</summary>
        [DisplayAttribute(Description = "Old password is incorrect.")]
        V008,

        /// <summary>Username is not Confirm.</summary>
        [DisplayAttribute(Description = "Username is not Confirm.")]
        V009,

        /// <summary>Username or Password was incorrect.</summary>
        [DisplayAttribute(Description = "Username or Password was incorrect.")]
        V010,

        /// <summary>2FA Code invalid..</summary>
        [DisplayAttribute(Description = "2FA Code invalid..")]
        T001,

        /// <summary>DateFrom DateTo Overlap.</summary>
        [DisplayAttribute(Description = "มีช่วงเวลาของ DateFrom กับ DateTo คาบเกี่ยวกัน")]
        D001,


        // overlap
    }
}
