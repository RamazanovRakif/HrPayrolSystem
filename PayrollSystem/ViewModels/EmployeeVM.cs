﻿using Microsoft.AspNetCore.Http;

using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class EmployeeVM
    {
        public IEnumerable<Employee> Employees { get; set; }

        public Employee Employee { get; set; }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FatherName { get; set; }


        public DateTime Birtday { get; set; }

        [Required]
        public string Residence { get; set; }

        [Required]
        public string DistrictRegistration { get; set; }

        [Required]
        [RegularExpression(@"\d{8}", ErrorMessage = "Invalid type. Must be 8 character")]
        public string PersonalityCardNumber { get; set; }


        public DateTime PersonalityCardEndDate { get; set; }

        [Required]
        public string OldWorkPlaces { get; set; }

        public IEnumerable<Gender> Genders { get; set; }
        [Required]
        public int SelectedGender { get; set; }

        public IEnumerable<MaritalStatus> Maritals { get; set; }
        [Required]
        public int SelectedMarital { get; set; }

        public IEnumerable<Education> Educations { get; set; }
        public int SelectedEducation { get; set; }

        public string EducationText { get; set; }
        public string GenderText { get; set; }
        public string MaritalStatusText { get; set; }


        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
