   M S B A M L   `   `   `  ����J  FBookstore.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Bookstore.ViewsBookstore.Views  5   	        Bookstore.Views.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Bookstore.Views     5   	   8
syncfusion!http://schemas.syncfusion.com/wpf     65   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      �� .+�5
   
   o� $��25��6   $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $��New Project��6   63   m� 5      $��Open Project��6   .@�5      m� $��WinForms��6   63   m� 5      $	��WPF��6   6/   5      �� 5      m� 5      $
��Exit��6   6,   5      m� 5      $
��Edit��6   6(   m� 5      $
��View��6   6(   5      `� 5   
   $	��Top=�6   .�5      c� $��25��6   .@�5      �� -   5         � ToolTip$ New Book��5      .��5      �� $��/new.png��6   5      �� 5      $ 	Edit Book��6   .��5      �� $��/new.png��6   5       �� 5"      $ Delete Book��6   .��5#      �� $��/new.png��6   5$      �� 5%      �� 5&      $ Groups��6   .��5'      �� $��/new.png��6   5(      5)      5*      �� 5,   
   .@�5-      �� $
��List��6   .��5/      &   System.Windows.Controls.DataGrid  -   5          Name$ 	gridBooks��5/      $��Stretch=�6.   $��Stretch=�6L      AutoGenerateColumns$ False��50         HorizontalGridLinesBrush
 �����   RowBackground
 �����   AlternatingRowBackground
 �����"   VerticalScrollBarVisibility$ Visible=�52      $	��500��6;   	   
IsReadOnly$
	 True��6K   ��53      �� *Books+
   Columns
 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ ID�6U     57      $ Author��6-   $	 200 6]    6=   �� $ AUTHOR�6]     58      $ Title��6-   $	 250 6[    6<   �� $ TITLE�6[     59      $ 	Publisher��6-   $	 200 6g    6@   �� $ PublisherName�6g     5:      $ Group��6-   $	 200 6_    6<   �� $ 	GroupName�6_     5;      $
 Shop��6-   $	 100 6]    6;   �� $ ShopName�6]     5<      $
 City��6-   $	 100 6]    6;   �� $ CityName�6]     5=      $ Language��6-   $	 100 6e    6?   �� $ LanguageName�6e     5>      $ Pages��6-   $ 70 6`    6<   �� $ 
PAGE_COUNT�6`     5?      $
 Year��6-   $ 70 6a    6;   �� $ PUBLISH_YEAR�6a     5@      $ Edition��6-   $ 70 6_    6>   �� $ EDITION�6_     5A      $
 ISBN��6-   $	 100 6Y    6;   �� $
 ISBN�6Y     5B      $ Price��6-   $ 70 6[    6<   �� $ PRICE�6[     5C      $ Received��6-   $	 100 6f    6?   �� $ DATE_WHEN_GET�6f     5D      $ Format��6-   $	 100 6]    6=   �� $ FORMAT�6]   5F      5H      �� 5I      $��Details��6   5K      5L      5N      5O      