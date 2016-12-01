
using HayaTestUnit.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayaTestUnit.Views
{
    class MainPage
    {
        /// <summary>
        /// call the infor comes of the database
        /// </summary>
        public void callTopics()
        {
                AppDatabase myDataBase = new AppDatabase();

                List<string> topicList = new List<string>();
                List<int> percentList = new List<int>();

                foreach (var item in myDataBase.GetTopics().ToArray())
                {
                    topicList.Add(item.Name);
                    percentList.Add(item.Id);
                }
                //topics = topicList.ToArray();
                //percentages = percentList.ToArray();
            
        }

        /// <summary>
        /// this function return a list of topics
        /// </summary>
        public List<string> topicList()
        {
            AppDatabase myDataBase = new AppDatabase();

            List<string> myReturn = new List<string>();
            List<int> percentList = new List<int>();

            foreach (var item in myDataBase.GetTopics().ToArray())
            {
                myReturn.Add(item.Name);
                percentList.Add(item.Id);
            }
            //topics = topicList.ToArray();
            //percentages = percentList.ToArray();
            return myReturn;
        }

        /// <summary>
        /// this function will check if there are data into the database
        /// </summary>
        /// <returns></returns>
        public bool controlData()
        {
            DataController myController = new DataController();
            return myController.IsData;
        } 
        /// <summary>
        /// this function find to
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string findTopicById(int id)
        {
            AppDatabase myDataBase = new AppDatabase();
            
            if (myDataBase.GetTopic(id) != null)
                return myDataBase.GetTopic(id).Name;
            else
                return "";
        }

        /// <summary>
        /// this function return the percentage of each topic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int findPercentageByTopic(int id)
        {
            int myResult = 0;

            return myResult;
        }
    }
}
