# How to use ListView events using Prism Framework in Xamarin.Forms (SfListView)

You can use [SwipeEnded](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~SwipeEnded_EV.html) event in [Prism](https://prismlibrary.com/docs/index.html) Framework by using [Behavior](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior) in Xamarin.Forms [SfListView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior).

**XAML**

Left and right swipe template defined.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage">
    <ContentPage.Behaviors>
        <local:Behavior/>
    </ContentPage.Behaviors>
    <ContentPage.Content>
        <StackLayout>
            <syncfusion:SfListView x:Name="listView" ItemSize="60" ItemsSource="{Binding ContactsInfo}" AllowSwiping="True" SwipeOffset="120">
                <syncfusion:SfListView.ItemTemplate >
                    <DataTemplate>
                        <Grid x:Name="grid">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Image Source="{Binding ContactImage}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="50" WidthRequest="50"/>
                            <Grid Grid.Column="1" RowSpacing="1" Padding="10,0,0,0" VerticalOptions="Center">
                                <Label LineBreakMode="NoWrap" TextColor="#474747" Text="{Binding ContactName}"/>
                                <Label Grid.Row="1" Grid.Column="0" TextColor="#474747" LineBreakMode="NoWrap" Text="{Binding ContactNumber}"/>
                            </Grid>
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
                <syncfusion:SfListView.LeftSwipeTemplate>
                    <DataTemplate>
                        <Grid BackgroundColor="SlateBlue">
                            <Label Text="Left swipe view" HorizontalOptions="Center" VerticalOptions="Center"/>
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.LeftSwipeTemplate>
                <syncfusion:SfListView.RightSwipeTemplate>
                    <DataTemplate>
                        <Grid BackgroundColor="SlateBlue">
                            <Label Text="Right swipe view" HorizontalOptions="Center" VerticalOptions="Center"/>
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.RightSwipeTemplate>
            </syncfusion:SfListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```
**C#**

Trigger **SwipeEnded** event for ListView and reset the swipe based on [SwipeOffset](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~SwipeOffset.html) value using [ResetSwipe](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ResetSwipe.html) method in Behavior class.
``` c#
namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView ListView;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.SwipeEnded += ListView_SwipeEnded;
            base.OnAttachedTo(bindable);
        }

        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset > 100)
                ListView.ResetSwipe();
        }
    }
}
```
