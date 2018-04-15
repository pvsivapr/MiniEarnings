using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace YenCash
{
    public partial class TestView : ContentPage
    {
        public ObservableCollection<SubjectGroup> quizGroup;
        string pageType;
        List<QuizTopic> quizTopics;
        public TestView(string[] pageSettings)
        {
            InitializeComponent();
            pageType = pageSettings[0];
            if (pageType == "MasterPage")
            {
                imageMainNavigation.Source = ImageSource.FromFile("MenuHamBurger.png");
            }
            else
            {
                imageMainNavigation.Source = ImageSource.FromFile("LeftArrowWhite.png");
            }

            GetListViewData();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 38;

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
                var searchValue = (e.NewTextValue).ToLower();

                List<QuizTopic> quizsTopics = quizTopics.Where(X => X.TopicName.ToLower().Contains(searchValue)).ToList(); //).Distinct().OrderBy(s => s).ToList();

                List<string> groupNames = quizsTopics.Select(X => X.GroupName).Distinct().OrderBy(s => s).ToList();
                quizGroup = new ObservableCollection<SubjectGroup>();
                foreach (var item in groupNames)
                {
                    try
                    {
                        List<Subject> subLists = new List<Subject>();
                        foreach (var items in quizsTopics)
                        {
                            if (item == items.GroupName)
                            {
                                subLists.Add(new Subject
                                {
                                    GroupName = item,
                                    Name = items.TopicName
                                });
                            }
                        }
                        quizGroup.Add(new SubjectGroup { GPName = item, SubjectsList = subLists });
                    }
                    catch (Exception ex)
                    {
                        PrintLog.PublishLog(ex);
                    }
                }

                GetLayouts(quizGroup);

                //if (string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue == "" && e.NewTextValue == null)
                //{
                //    listQuizTopics.ItemsSource = quizGroup;
                //}
                //else
                //{
                //    ObservableCollection<QuizGroup> listViewSearchedItems = new ObservableCollection<QuizGroup>();
                //    foreach (var sourceGroupItem in quizGroup)
                //    {
                //        var groupItemPresent = sourceGroupItem.Where(X => X.TopicName.ToLower().Contains(searchValue)).Any();
                //        if (groupItemPresent)
                //        {
                //            var groupItem = new QuizGroup { GroupName = sourceGroupItem.GroupName };
                //            var topicsWithSearchValue = sourceGroupItem.Where(X => X.TopicName.ToLower().Contains(searchValue)).ToList();
                //            foreach (var topicItem in topicsWithSearchValue)
                //            {
                //                groupItem.Add(topicItem);
                //            }
                //            listViewSearchedItems.Add(groupItem);
                //        }
                //    }
                //    listQuizTopics.ItemsSource = listViewSearchedItems;
                //}
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
                if (pageType == "MasterPage")
                {
                    var ParentPage = (MasterDetailPage)this.Parent;
                    ParentPage.IsPresented = (ParentPage.IsPresented == false) ? true : false;
                }
                else
                {
                    Navigation.PopModalAsync(false);
                }
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
                //listQuizTopics.ItemsSource = quizGroup;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        public void GetListViewData()
        {
            try
            {
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
                quizGroup = new ObservableCollection<SubjectGroup>();
                foreach(var item in groupNames)
                {
                    try
                    {
                        List<Subject> subLists = new List<Subject>();
                        foreach (var items in quizTopics)
                        {
                            if (item == items.GroupName)
                            {
                                subLists.Add(new Subject
                                {
                                    GroupName = item,
                                    Name = items.TopicName
                                });
                            }
                        }
                        quizGroup.Add(new SubjectGroup { GPName = item, SubjectsList = subLists });
                    }
                    catch(Exception ex)
                    {
                        PrintLog.PublishLog(ex);
                    }
                }

                GetLayouts(quizGroup);

                //List<string> groupNames = quizTopics.Select(X => X.GroupName).Distinct().OrderBy(s => s).ToList();
                //quizGroup = new ObservableCollection<QuizGroup>();
                //foreach (var selectedGroup in groupNames)
                //{
                //    var selectedTopics = quizTopics.Where(X => X.GroupName == selectedGroup).ToList();
                //    var _quizGroup = new QuizGroup()
                //    {
                //        GroupName = selectedGroup
                //    };
                //    foreach (var topics in selectedTopics)
                //    {
                //        _quizGroup.Add(topics);
                //    }
                //    quizGroup.Add(_quizGroup);
                //}
                //listQuizTopics.ItemsSource = quizGroup;

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        public void GetLayouts(ObservableCollection<SubjectGroup> itemsGroup)
        {
            try
            {
                try
                {
                    if (stackListHolder.Children.Count > 0)
                    {
                        stackListHolder.Children.Clear();
                    }
                }
                catch (Exception ex)
                {
                    PrintLog.PublishLog(ex);
                }
                if(quizGroup != null && quizGroup.Count != 0)
                {
                    OpenCloseLayout layout = new OpenCloseLayout(itemsGroup)
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    stackListHolder.Children.Add(layout);
                }
            }
            catch(Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }
    }

    public class SubjectGroup
    {
        public string GPName { get; set; }

        public List<Subject> SubjectsList { get; set; }
    }

    public class Subject
    {
        public string GroupName { get; set; }

        public string Name { get; set; }
    }

    public class OpenCloseLayout : StackLayout
    {
        public OpenCloseLayout(ObservableCollection<SubjectGroup> viewsList)
        {
            bool isLayoutOpen = false;
            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            foreach(var groupItem in viewsList)
            {
                Label labelName = new Label()
                {
                    Text = groupItem.GPName,//"",//parameters[0],
                    TextColor = Color.Black,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                BoxView boxTouch = new BoxView()
                {
                    Color = Color.Transparent,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                TapGestureRecognizer boxGroupTap = new TapGestureRecognizer();
                boxGroupTap.NumberOfTapsRequired = 1;
                boxTouch.GestureRecognizers.Add(boxGroupTap);
                Grid gridHolder = new Grid()
                {
                    RowDefinitions =
                    {
                        new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    },
                    HeightRequest = height * 8,
                    BackgroundColor = Color.Orange,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start
                };
                gridHolder.Children.Add(labelName, 0, 0);
                gridHolder.Children.Add(boxTouch, 0, 0);
                StackLayout stackChildrenHolder = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start
                };
                StackLayout stackHolder = new StackLayout()
                {
                    Children = { gridHolder, stackChildrenHolder },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start
                };
                StackLayout stackChildHolder = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start
                };


                foreach (var item in groupItem.SubjectsList)
                {

                    Label labelChildName = new Label()
                    {
                        Text = item.Name,//"",//parameters[0],
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Start,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    Grid gridChildHolder = new Grid()
                    {
                        RowDefinitions =
                        {
                            new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                        },
                        ColumnDefinitions =
                        {
                            new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                        },
                        HeightRequest = height * 8,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    gridChildHolder.Children.Add(labelChildName, 0, 0);
                    stackChildHolder.Children.Add(gridChildHolder);
                }
                boxGroupTap.Tapped += (object sender, EventArgs e) =>
                {
                    try
                    {
                        if(isLayoutOpen == false)
                        {
                            stackChildrenHolder.Children.Add(stackChildHolder);
                            isLayoutOpen = true;
                        }
                        else
                        {
                            stackChildrenHolder.Children.Clear();
                            isLayoutOpen = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        PrintLog.PublishLog(ex);
                    }
                };
                Children.Add(stackHolder);

            }
        }
    }

    //public class OpenCloseChildLayout : StackLayout
    //{
    //    public OpenCloseChildLayout(string[] parameters)
    //    {
    //        Label labelName = new Label()
    //        {
    //            Text = parameters[0],
    //            TextColor = Color.Black,
    //            HorizontalTextAlignment = TextAlignment.Start,
    //            VerticalTextAlignment = TextAlignment.Center,
    //            HorizontalOptions = LayoutOptions.FillAndExpand,
    //            VerticalOptions = LayoutOptions.CenterAndExpand
    //        };
    //        Grid gridHolder = new Grid()
    //        {
    //            RowDefinitions =
    //            {
    //                new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
    //            },
    //            ColumnDefinitions =
    //            {
    //                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
    //            },
    //            HorizontalOptions = LayoutOptions.FillAndExpand,
    //            VerticalOptions = LayoutOptions.CenterAndExpand
    //        };
    //        gridHolder.Children.Add(labelName, 0, 0);
    //        Children.Add(gridHolder);
    //    }
    //}
}