using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(50, ErrorMessage = ("超过50字了")), Required]
        public string Name { get; set; }
        /// <summary>
        /// 作者邮箱
        /// </summary>
        [MaxLength(100, ErrorMessage = ("超过100字了"))]
        public string Email { get; set; }
        /// <summary>
        /// 是否参与统计
        /// 0:未参与 1:参与
        /// </summary>
        public int? Type { get; set; }
    }
}
