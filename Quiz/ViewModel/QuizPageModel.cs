using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;


namespace Quiz.ViewModel
{
    class QuizPageModel :NotifyPropertyChanged
    {
public static List<Question> questionList { private get; set; }
        public static List<Question> QuestionList { private get; set; }
        public string currentQuestion;
        public int questionIndex = 0;
        public int pointCounter = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand userResponse { protected set; get; }
        IList<string> imageList = new List<string>();
        int index;

        public QuizPageModel() {

            imageList.Add("Bronn.jpg");
            imageList.Add("Daenerys.jpg");
            imageList.Add("JonSnow.jpg");
            imageList.Add("Sansa.jpg");
            imageList.Add("Tyrion.jpg");

            questionList = new List<Question>
                {
                    new Question("Do you prefer 1) Fire or 2) Ice?"),
                    new Question("Do you prefer 1) Blood or 2) Water?"),
                    new Question("Do you prefer 1)to always pay your debt  or 2)to never die ?"),
                    new Question("Do you prefer to have 1) Dragon or 2) Wolf?"),
                    new Question("Do you prefer to 1) Rule or 2) Die?")
                };

           
            currentQuestion = questionList[questionIndex].text;

            
            userResponse = new Command<string>((key) =>
            {
                int response;
                if (key == "True")
                {
                   
                    pointCounter += 25;
                    response = 1;
                }
                else
                {
                    
                    pointCounter -= 25;
                    response = 0;
                }
               
                if (questionIndex < questionList.Count)
                {
                    questionList[questionIndex].answer = response;
                }
                nextQuestion();
            },
            (key) =>
            {
                return questionIndex >= questionList.Count ? false : true;
            });

        }

       
        public void nextQuestion()
        {
            if (questionIndex < questionList.Count - 1)
            {
                CurrentQuestion = questionList[++questionIndex].text;
            }
            else
            {
                if (pointCounter < 0)
                {
                    returnedCharacter("Tyrion");
                    index = 4;
                    

                }
                else if (pointCounter < 0 && pointCounter <= 50)
                {
                    returnedCharacter("Sansa");
                    index = 3;
                }
                else if (pointCounter < 50 && pointCounter <= 75)
                {
                    returnedCharacter("Jon Snow");
                    index = 2;
                }
                else if (pointCounter < 75 && pointCounter <= 100)
                {
                    returnedCharacter("Daenerys");
                    index = 1;
                }
                else
                {
                    returnedCharacter("Bronn");
                    index = 0;
                }
            }
        }



       // public void returnedCharacter(string value,int index)
        public void returnedCharacter(string value)
        {
            CurrentQuestion = "Wow, you're such a " + value + "!";
            //theImage.Source = imageList[index];

            ((Command)userResponse).ChangeCanExecute();
        }

       
       
        public string CurrentQuestion
        {
            protected set
            {
                if (currentQuestion != value)
                {
                    currentQuestion = value;
                    OnPropertyChanged("CurrentQuestion");
                }
            }
            get { return currentQuestion; }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

       

    

    }

    

