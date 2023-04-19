﻿

using System;

namespace EmployeeDemo.Database.Models;

public class Employee
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string MiddleName { get; set; }
	public DateTime DateOfBirth { get; set; }
}
