using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Created By: Daniel Swain
 * Date: 22/08/2016
 * Update By: Oscar Moreno
 * Date: 20/10/2016
 * 
 * Class representing the database model for the topics table
 */
namespace HayaTestUnit.Models
{
    public class Topic
    {
        // Empty constructor for a Topic model object
        public Topic()
        {
        }

        // The table properties, not the SQLite plugin can set these simply
        // The line after a property declared in [] brackets is what the [] refer to
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int Order { get; set; }
        public string VideoUrl { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
