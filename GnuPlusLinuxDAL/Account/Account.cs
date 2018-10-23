using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GnuPlusLinuxDAL
{
    public class Account
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int accountId { get; set; }

		[Required]
		public string username { get; set; }

		[Required]
		public string password { get; set; }

		[Compare("password", ErrorMessage = "Passwords do not match")]
		public string confirmPw { get; set; }

		[Required]
		public string email { get; set; }

		[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime dateJoined { get; set; }

		[Required]
		public bool isAdmin { get; set; }

		[Required]
		public bool isMod { get; set; }

		// Toon Specific Information
		public string toonName    { get; set; }
		public byte   toonClass   { get; set; }
		public byte   role        { get; set; }
		public byte   profession1 { get; set; }
		public byte   profession2 { get; set; }
	}
}
