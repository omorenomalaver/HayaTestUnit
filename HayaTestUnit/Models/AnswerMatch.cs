using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Created By: Daniel Swain
 * Date: 22/08/2016
 * 
 * Class representing the database model for a AnswerMatch table
 */
namespace HayaTestUnit.Models
{
    public class AnswerMatch
    {
        // Empty constructor for a AnswerMatch object
        public AnswerMatch()
        {
        }

        // The table properties, not the SQLite plugin can set these simply
        // The line after a property declared in [] brackets is what the [] refer to
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Indexed]
        public int question { get; set; }
        [Indexed]
        public int right_answer { get; set; }
        [Indexed]
        public int selected_answer { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
