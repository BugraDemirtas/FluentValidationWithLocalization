﻿namespace FluentValidationWithLocalization.Model
{
	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public string PhoneNumber { get; set; }

		public UserSettings Settings { get; set; }
	}


	public class UserSettings
	{
		public string Test { get; set; }

		public string Test2 { get; set; }
	}
}
