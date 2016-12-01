using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Created By: Daniel Swain
 * Date: 22/08/2016
 * 
 * Class representing the database model for a AnswerAvailable table
 */
namespace HayaTestUnit.Models
{
    public class AnswerAvailable
    {
        // Empty constructor for a AnswerAvailable object
        public AnswerAvailable()
        {
        }

        // The table properties, not the SQLite plugin can set these simply
        // The line after a property declared in [] brackets is what the [] refer to
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
