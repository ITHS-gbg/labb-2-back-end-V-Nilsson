﻿namespace WestCoast_Education.DAL.Models
{
    public class Course
    {
        public enum CourseLevel
        {
            Beginner,
            Intermediate,
            Advanced
        }
        public Course(string title, string description, int length)
        {
            Title = title;
            Description = description;
            Length = length;
        }
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }

        public double? Rating { get; set; } = null;

        // Status, Active or retired. Gets set as active when we initiate a course
        public bool IsActive { get; set; } = true;

        public CourseLevel Level { get; set; } 

    }
}
