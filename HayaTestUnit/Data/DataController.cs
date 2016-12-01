
using HayaTestUnit.Models;
using System;
using System.Collections.Generic;
using System.Data;
/*
 * Created: Oscar Moreno
 * Date: 01/11/2016
*/
namespace HayaTestUnit.data
{
    /// <summary>
    /// this class will check data access and will invoke the web service if are not data
    /// </summary>
    public class DataController
    {
        
        private bool isData;
        public DataController()
        {
            
        }
        /// <summary>
        /// this variable can be invoke to 
        /// </summary>
        public bool IsData
        {
            get
            {
                checkData();
                return isData;
            }
            
        }

        /// <summary>
        /// this function will check if there is internal data
        /// </summary>
        private void checkData()
        {
            try
            {
                AppDatabase myDataBase = new AppDatabase();

                Topic myTopic = myDataBase.GetTopic(1);

                if (myTopic==null)
                {
                    invokeData();
                }
                else
                {
                    isData = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error"+ e.Message);
                isData = false;
                throw;
            }
            
        }

        /// <summary>
        /// this function will invoke data to insert into internal database
        /// </summary>
        public void invokeData()
        {
            try
            {
                
                if (callWebService())
                {
                    // if there is a web service, will be invoke here to add data into internal database
                }
                else
                {
                    // if is not webservice access, create a fake data untill can connect to the database
                    createTemporalData();
                }
            }
            catch (Exception)
            {
                isData = false;
                throw;
            }
            
        }
        /// <summary>
        /// this function will call the webservices, then will add the data to insert into the internal database
        /// </summary>
        /// <returns></returns>
        private bool callWebService()
        {
            bool isSuccess = false;
            try
            {
                //donwloadData();
                    ///isSuccess = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                isData = false;
                throw;
            }

            return isSuccess;
        }

        /// <summary>
        /// this function gives to the program a list of fake topics in case the program cannot access to the external database
        /// </summary>
        private void addFakeTopics()
        {
            AppDatabase myDataBase = new AppDatabase();
            List<Topic> topicList = new List<Topic>();
            
            /// fake topic data
            Topic myTopic = new Topic();
            myTopic.Name = "topic 1";
            myTopic.Info = "topic test 1";
            myTopic.Order = 1;
            myTopic.VideoUrl = "none";
            myTopic.Image = "none";
            myTopic.Icon = "none";
            topicList.Add(myTopic);
            myTopic = new Topic();
            myTopic.Name = "topic 2";
            myTopic.Info = "topic test 2";
            myTopic.Order = 2;
            myTopic.VideoUrl = "none";
            myTopic.Image = "none";
            myTopic.Icon = "none";
            topicList.Add(myTopic);
            myTopic = new Topic();
            myTopic.Name = "topic 3";
            myTopic.Info = "topic test 3";
            myTopic.Order = 3;
            myTopic.VideoUrl = "none";
            myTopic.Image = "none";
            myTopic.Icon = "none";
            topicList.Add(myTopic);
            // fake question data
            myDataBase.insertTopics(topicList.ToArray());
        }

        /// <summary>
        /// this function gives to the program a list of fake questions in case the program cannot access to the external database
        /// </summary>
        private void addFakeQuestions()
        {
            AppDatabase myDataBase = new AppDatabase();
            List<Question> questionList = new List<Question>();
            Question myQuestion = new Question();
            myQuestion.Name = "question 1";
            myQuestion.Info = "question 1 topic 1";
            myQuestion.Order = 1;
            myQuestion.DragAndDrop = false;
            myQuestion.TopicId = 1;
            questionList.Add(myQuestion);
            myQuestion = new Question();
            myQuestion.Name = "question 2";
            myQuestion.Info = "question 2 topic 1";
            myQuestion.Order = 2;
            myQuestion.DragAndDrop = true;
            myQuestion.TopicId = 1;
            questionList.Add(myQuestion);
            myQuestion = new Question();
            myQuestion.Name = "question 3";
            myQuestion.Info = "question 3 topic 1";
            myQuestion.Order = 3;
            myQuestion.DragAndDrop = false;
            myQuestion.TopicId = 1;
            questionList.Add(myQuestion);
            myQuestion = new Question();
            myQuestion.Name = "question 1";
            myQuestion.Info = "question 1 topic 2";
            myQuestion.Order = 1;
            myQuestion.DragAndDrop = true;
            myQuestion.TopicId = 2;
            questionList.Add(myQuestion);
            myQuestion = new Question();
            myQuestion.Name = "question 2";
            myQuestion.Info = "question 2 topic 2";
            myQuestion.Order = 2;
            myQuestion.DragAndDrop = false;
            myQuestion.TopicId = 2;
            questionList.Add(myQuestion);
            myQuestion = new Question();
            myQuestion.Name = "question 1";
            myQuestion.Info = "question 1 topic 3";
            myQuestion.Order = 1;
            myQuestion.DragAndDrop = false;
            myQuestion.TopicId = 3;
            questionList.Add(myQuestion);
            myDataBase.insertQuestions(questionList.ToArray());
        }

        /// <summary>
        /// this funtion call fake data for topics and questions
        /// </summary>
        public void createTemporalData()
        {
            addFakeTopics();
            addFakeQuestions();
        }
    }
}
