using HayaTestUnit.data;
using HayaTestUnit.Models;
using HayaTestUnit.Views;
using Xunit;

namespace HayaTestUnit
{
    public class Class1
    {

        /// <summary>
        /// this fact will check if there are values into the internal database
        /// </summary>
        [Fact]
        public void checkDatabase()
        {
            MainPage myPage = new MainPage();
            Assert.False(myPage.controlData());
        }

        /// <summary>
        /// this fact will check if there are an exactly data into the database
        /// </summary>
        [Fact]
        public void checkValuesDatabase()
        {
            MainPage myPage = new MainPage();
            Assert.Equal("topic 1", myPage.findTopicById(1));
        }

        /// <summary>
        /// this function will check if insert values into the database is succesful
        /// </summary>
        [Fact]
        public void addNewValues()
        {
            MainPage myPage = new MainPage();
            Assert.True(addTopic("topic 4"));
        }

        /// <summary>
        /// this function insert a value into table topic
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns></returns>
        private bool addTopic(string topicName)
        {
            try
            {
                Topic myTopic = new Topic();
                myTopic.Name = topicName;
                myTopic.Info = "topic test 4";
                myTopic.Order = 1;
                myTopic.VideoUrl = "none";
                myTopic.Image = "none";
                myTopic.Icon = "none";
                AppDatabase myDataBase = new AppDatabase();
                myDataBase.insertTopic(myTopic);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// this theory will ask values to the database, some of then already exists, such 1, 2, 3 and 4
        /// I would like to check what happen when the app is asked for values are in it
        /// </summary>
        /// <param name="value">a integer value</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void checkMultipleValuesDatabase(int value)
        {
            MainPage myPage = new MainPage();
            Assert.Equal("topic " + value.ToString(), myPage.findTopicById(value));
        }
    }
}
