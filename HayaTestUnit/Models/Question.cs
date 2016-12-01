using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Created By: Daniel Swain
 * Date: 22/08/2016
 * 
 * Class representing the database model for the questions table
 */
namespace HayaTestUnit.Models
{
    public class Question
    {
        // Empty constructor for a Question object
        public Question()
        {
        }

        // The table properties, not the SQLite plugin can set these simply
        // The line after a property declared in [] brackets is what the [] refer to
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int Order { get; set; }
        public bool DragAndDrop { get; set; }
        public int TopicId { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
