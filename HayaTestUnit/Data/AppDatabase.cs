using System;
using System.Collections.Generic;
using System.IO;
using HayaTestUnit.Models;
using System.Linq;
using SQLite;
/*
 * Created: Daniel Swain
 * Date: 22/08/2016
*/
namespace HayaTestUnit.data
{
    /// <summary>
    ///Class representing the shared database code used in the Android and iOS projects
    ///to access the application database for the quiz app.Includes the accessing and save methods
    ///for the model objects in HayaProject/Models
    /// </summary>
    public class AppDatabase
    {
        /// <summary>
        /// this locker object is used to prevent concurrency issues with our database accesses
        /// </summary>
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Compiler conditionals to specify the database path for each platform
        /// </summary>
        string DatabasePath
        {
            get
            {
                var sqliteFilename = "HayaSQLite.db3";
#if __IOS__
					// iOS OS specific database path code.
					string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
					string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
					var path = Path.Combine(libraryPath, sqliteFilename);
#elif __ANDROID__
					// Android OS specific database path code.
                	string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
                	var path = Path.Combine(documentsPath, sqliteFilename);
#else
                // WinPhone
                string commonFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                //string myAppFolder = Path.Combine(commonFolder, "MyAppDataFolder");
                var path = Path.Combine(commonFolder, sqliteFilename);
                #endif
                return path;
            }
        }
        /// <summary>
        /// constructor of the class
        /// </summary>
        public AppDatabase()
        {
            try
            {
                // Get a connection to the database using the compiled databasePath from above
                database = new SQLiteConnection(DatabasePath);
                // if the internal database is empty of objects, must create tables
                if (database.GetTableInfo("Topic").Count() == 0)
                {
                    database.CreateTable<AnswerAvailable>();
                    database.CreateTable<AnswerMatch>();
                    database.CreateTable<Question>();
                    database.CreateTable<Topic>();
                }
                
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get a single topic with the given id from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Topic> GetTopics()
        {
            lock (locker)
            {
                return (from i in database.Table<Topic>() select i).ToList();
            }
        }

        /// <summary>
        /// Get a single topic with the given id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Topic GetTopic(int id)
        {
            lock (locker)
            {
                return database.Table<Topic>().FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Get a list of questions for a topic
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        public IEnumerable<Question> GetQuestionsForTopic(int topicId)
        {
            lock (locker)
            {
                return database.Query<Question>("SELECT * FROM [Question] WHERE [topic] = {0}", topicId);
            }
        }

        /// <summary>
        /// Get a list of answers available for a given question id
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public IEnumerable<AnswerAvailable> GetAnswersForQuestion(int questionId)
        {
            lock (locker)
            {
                return database.Query<AnswerAvailable>("SELECT * FROM [AnswerAvailable] WHERE [question] = {0}", questionId);
            }
        }


        /// <summary>
        /// Save a selected answer into the database. This returns the id of the saved answer if successful
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int SaveAnswerMatch(AnswerMatch match)
        {
            lock (locker)
            {
                // A selection already exists so lets update the existing item
                if (match.id != 0)
                {
                    database.Update(match);
                    return match.id;
                }
                // No match exists in the db at the moment so insert the new selection
                else
                {
                    return database.Insert(match);
                }
            }
        }

        /// <summary>
        /// insert a topic into the internal database
        /// </summary>
        /// <param name="myTopics">a topic to be added into the internal database</param>
        public void insertTopic(Topic myTopics)
        {
            database.Insert(myTopics);
        }

        /// <summary>
        /// this function will add a list of topics into the internal database
        /// </summary>
        /// <param name="myTopics">a list of topics to be added into the internal database</param>
        public void insertTopics(Topic[] myTopics)
        {
            foreach(var myTopic in myTopics)
            {
                insertTopic(myTopic);
            }
        }

        public void insertQuestion(Question myQuestion)
        {
            database.Insert(myQuestion);
        }

        /// <summary>
        /// this function will add a list of questions into the iternal database
        /// </summary>
        /// <param name="myQuestions">a list of questions to be added</param>
        public void insertQuestions(Question[] myQuestions)
        {
            foreach (var myQuestion in myQuestions)
            {
                insertQuestion(myQuestion);
            }
        }
    }
}
