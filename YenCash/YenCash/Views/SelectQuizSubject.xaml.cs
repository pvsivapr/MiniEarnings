using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace YenCash
{
    public partial class SelectQuizSubject : ContentPage
    {
        public ObservableCollection<QuizGroup> quizGroup;

        public SelectQuizSubject()
        {
            InitializeComponent();

            listQuizTopics.GroupHeaderTemplate = new DataTemplate(typeof(GroupUIView));
            listQuizTopics.ItemTemplate = new DataTemplate(typeof(TopicUIView));
            GetListViewData();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 38;

            listQuizTopics.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => 
            {
                try
                {
                    var selectedItem = ((ListView)sender).SelectedItem as QuizTopic;
                    if(selectedItem == null)
                    {
                        return;
                    }
                    Navigation.PushModalAsync(new Quiz());
                    ((ListView)sender).SelectedItem = null;
                }
                catch (Exception ex)
                {
                    PrintLog.PublishLog(ex);
                }
            };


            //imageSudoku.HeightRequest = imageMetrices;
            //imageSudoku.WidthRequest = imageMetrices;

            //gridDataInput.HeightRequest = height * 25;

        }

        public void GetListViewData()
        {
            List<QuizTopic> quizTopics;
            try
            {
                /*
                quizTopics = new ObservableCollection<List<QuizTopic>>()
                {
                    new List<QuizTopic>()
                    {
                        new QuizTopic(){TopicName="Topic01"},
                        new QuizTopic(){TopicName="Topic02"},
                        new QuizTopic(){TopicName="Topic03"},
                        new QuizTopic(){TopicName="Topic04"},
                        new QuizTopic(){TopicName="Topic05"},
                        new QuizTopic(){TopicName="Topic06"}
                    },
                    new List<QuizTopic>()
                    {
                        new QuizTopic(){TopicName="Topic11"},
                        new QuizTopic(){TopicName="Topic12"},
                        new QuizTopic(){TopicName="Topic13"},
                        new QuizTopic(){TopicName="Topic14"},
                        new QuizTopic(){TopicName="Topic15"},
                        new QuizTopic(){TopicName="Topic16"}
                    },
                    new List<QuizTopic>()
                    {
                        new QuizTopic(){TopicName="Topic21"},
                        new QuizTopic(){TopicName="Topic22"},
                        new QuizTopic(){TopicName="Topic23"},
                        new QuizTopic(){TopicName="Topic24"},
                        new QuizTopic(){TopicName="Topic25"},
                        new QuizTopic(){TopicName="Topic26"}
                    },
                    new List<QuizTopic>()
                    {
                        new QuizTopic(){TopicName="Topic31"},
                        new QuizTopic(){TopicName="Topic32"},
                        new QuizTopic(){TopicName="Topic33"},
                        new QuizTopic(){TopicName="Topic34"},
                        new QuizTopic(){TopicName="Topic35"},
                        new QuizTopic(){TopicName="Topic36"}
                    }
                };
                */

                quizTopics = new List<QuizTopic>()
                {
                    new QuizTopic(){GroupName="Group0", TopicName="Topic01"},
                    new QuizTopic(){GroupName="Group0", TopicName="Topic02"},
                    new QuizTopic(){GroupName="Group0", TopicName="Topic03"},
                    new QuizTopic(){GroupName="Group0", TopicName="Topic04"},
                    new QuizTopic(){GroupName="Group0", TopicName="Topic05"},
                    new QuizTopic(){GroupName="Group0", TopicName="Topic06"},
                    new QuizTopic(){GroupName="Group1", TopicName="Topic11"},
                    new QuizTopic(){GroupName="Group1", TopicName="Topic12"},
                    new QuizTopic(){GroupName="Group1", TopicName="Topic13"},
                    new QuizTopic(){GroupName="Group1", TopicName="Topic14"},
                    new QuizTopic(){GroupName="Group1", TopicName="Topic15"},
                    new QuizTopic(){GroupName="Group1", TopicName="Topic16"},
                    new QuizTopic(){GroupName="Group2", TopicName="Topic21"},
                    new QuizTopic(){GroupName="Group2", TopicName="Topic22"},
                    new QuizTopic(){GroupName="Group2", TopicName="Topic23"},
                    new QuizTopic(){GroupName="Group2", TopicName="Topic24"},
                    new QuizTopic(){GroupName="Group2", TopicName="Topic25"},
                    new QuizTopic(){GroupName="Group2", TopicName="Topic26"},
                    new QuizTopic(){GroupName="Group3", TopicName="Topic31"},
                    new QuizTopic(){GroupName="Group3", TopicName="Topic32"},
                    new QuizTopic(){GroupName="Group3", TopicName="Topic33"},
                    new QuizTopic(){GroupName="Group3", TopicName="Topic34"},
                    new QuizTopic(){GroupName="Group3", TopicName="Topic35"},
                    new QuizTopic(){GroupName="Group3", TopicName="Topic36"}
                };

                List<string> groupNames = quizTopics.Select(X => X.GroupName).Distinct().OrderBy(s => s).ToList();
                quizGroup = new ObservableCollection<QuizGroup>();
                foreach(var selectedGroup in groupNames)
                {
                    var selectedTopics = quizTopics.Where(X => X.GroupName == selectedGroup).ToList();
                    var _quizGroup = new QuizGroup()
                    {
                        GroupName = selectedGroup
                    };
                    foreach (var topics in selectedTopics)
                    {
                        _quizGroup.Add(topics);
                    }
                    quizGroup.Add(_quizGroup);
                }

                listQuizTopics.ItemsSource = quizGroup;

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }


        private void SearchData(object sender, TextChangedEventArgs e)
        {

            /*
            var sourceItems = DomainfinalList;
            ObservableCollection<DomainAndStoresDetails> searchedList = new ObservableCollection<DomainAndStoresDetails>();
            try
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue == "" && e.NewTextValue == null)
                {
                    listview.ItemsSource = DomainfinalList;
                }
                else
                {
                    foreach (var item in sourceItems)
                    {
                        var data = item.Where(X => (X.Name.ToLower()).Contains(e.NewTextValue.ToLower())).Any();
                        if (data == true)
                        {
                            var dataGroup = new DomainAndStoresDetails { DomainName = item.DomainName, DomainUniqueKey = item.DomainUniqueKey, ImageSource = item != null ? item.ImageSource : "", StartColor = item.StartColor, EndColor = item.EndColor };
                            var storeItemsObtained = item.Where(X => (X.Name.ToLower()).Contains(e.NewTextValue.ToLower())).ToList();
                            foreach (var storeItems in storeItemsObtained)
                            {
                                dataGroup.Add(storeItems);
                            }
                            searchedList.Add(dataGroup);
                        }
                    }
                    listview.ItemsSource = searchedList;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            */

            try
            {
                var searchValue = e.NewTextValue;
                if (string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue == "" && e.NewTextValue == null)
                {
                    listQuizTopics.ItemsSource = quizGroup;
                }
                else
                {
                    ObservableCollection<QuizGroup> listViewSearchedItems = new ObservableCollection<QuizGroup>();
                    foreach(var sourceGroupItem in quizGroup)
                    {
                        var groupItemPresent = sourceGroupItem.Where(X => X.TopicName.ToLower().Contains(searchValue)).Any();
                        if(groupItemPresent)
                        {
                            var groupItem = new QuizGroup { GroupName = sourceGroupItem.GroupName };
                            var topicsWithSearchValue = sourceGroupItem.Where(X => X.TopicName.ToLower().Contains(searchValue)).ToList();
                            foreach(var topicItem in topicsWithSearchValue)
                            {
                                groupItem.Add(topicItem);
                            }
                            listViewSearchedItems.Add(groupItem);
                        }
                    }
                    listQuizTopics.ItemsSource = listViewSearchedItems;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void SearchTapped(object sender, EventArgs e)
        {
            try
            {
                SearchHolder.IsVisible = true;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void CloseTapped(object sender, EventArgs e)
        {
            try
            {
                SearchHolder.IsVisible = false;
                listQuizTopics.ItemsSource = quizGroup;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }
    }

    public class QuizGroup : ObservableCollection<QuizTopic>
    {
        public string GroupName { get; set; }
    }

    public class QuizTopic
    {
        public string GroupName { get; set; }
        public string TopicName { get; set; }
    }

    public class GroupUIView : ViewCell
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var bindableItem = BindingContext as QuizGroup;

            CustomLabel labelGroupName = new CustomLabel()
            {
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            labelGroupName.SetBinding(Label.TextProperty, new Binding("GroupName"));

            StackLayout stackHolder = new StackLayout()
            {
                Children = { labelGroupName },
                BackgroundColor = Color.Gray,
                HeightRequest = ((App.screenHeight) * 5) / 100,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            View = stackHolder;
        }
    }

    public class TopicUIView : ViewCell
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var bindableItem = BindingContext as QuizTopic;

            CustomLabel labelTopicName = new CustomLabel()
            {
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            labelTopicName.SetBinding(Label.TextProperty, new Binding("TopicName"));

            StackLayout stackHolder = new StackLayout()
            {
                Children = { labelTopicName },
                HeightRequest = ((App.screenHeight) * 8) / 100,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            View = stackHolder;
        }
    }
}