﻿using System.ComponentModel.DataAnnotations;

namespace My_First_Finance_App.Models
{
	public class IncomeSource
	{
		[Key]
		public int IncomeSourceId { get; set; }
		public string Name { get; set; }

		
		public ICollection<Salary> Salaries { get; set; }
	}
}
