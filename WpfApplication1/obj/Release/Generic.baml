   M S B A M L   `   `   `  ����   PresentationFramework.AerogJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  H DSearchTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>/clr-namespace:UIControls;assembly=SearchTextBox
UIControls R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   SearchTextBox_Background  �� Color  SearchTextBox_Foreground  SearchTextBox_Border �� 
StartPoint �� EndPoint � Color � Offset ! SearchTextBox_BorderMouseOver " SearchTextBox_SearchIconBorder & "SearchTextBox_SearchIconBackground , (SearchTextBox_SearchIconBorder_MouseOver 0 ,SearchTextBox_SearchIconBackground_MouseOver , (SearchTextBox_SearchIconBorder_MouseDown 0	 ,SearchTextBox_SearchIconBackground_MouseDown  
 SearchTextBox_LabelTextColor   UIControls.SearchTextBox �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �Name � ColumnDefinitions ��Name ��Name �� RelativeSource �� Path ��Name � ToolTip �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     RmwtJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5l/clr-namespace:UIControls;assembly=SearchTextBox  %  &	        &	      &	 "     &	 �     &	     &	 %    &	 6    &	 �    &	 !    &		 w    &	
     '       7   7  7  7 
 7  7  7  7  �� $  White���� $  Black���� $	 0,0&�$	 0,1&�.��� $ 	#FFABADB3��$
 0.05Q�� $ 	#FFE2E3EA��$
 0.07Q�� $ 	#FFE4E9EF��$ 1Q��� $	 0,0&�$	 0,1&�.��� $ 	#FF5C97C1��$
 0.05Q�� $ 	#FFB9D7EB��$
 0.07Q�� $ 	#FFC7E2F1��$ 1Q��� $  White���� $  White���� $	 0,0&�$	 0,1&�.��� $ 	#FFFFFFFF��$ 0Q�� $ 	#FFE5F4FC��$ 1Q��� $	 0,0&�$	 0,1&�.��� $ 	#FFE7F5FD��$ 0Q�� $ 	#FFD2EDFC��$	 0.5Q�� $ 	#FFB6E3FD��$
 0.51Q�� $ 	#FF9DD5F3��$ 1Q��� $	 0,0&�$	 0,1&�.��� $ 	#FFFFFFFF��$ 0Q�� $ 	#FFE5F4FC��$ 1Q��� $	 0,0&�$	 0,1&�.��� $ 	#FFE7F5FD��$ 0Q�� $ 	#FFD2EDFC��$	 0.5Q�� $ 	#FFB6E3FD��$
 0.51Q�� $ 	#FF9DD5F3��$ 1Q��� $
  Gray���� "   .���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  �@J�SnapsToDevicePixels . ��  �@  	LabelText$ Search����  �@�FocusVisualStyle Z� ��  �@  LabelTextColor8  ��  � �� �� "   .R��� $	 Border��#��z��#��z��#��z��._�� $
 
LayoutGrid�� �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $ PART_ContentHost��$��2q�$��0��$��Center=��� $ 	LabelText��$��2q�$��0��$��2,0,0,0q�$��Center=�$��Italic$�����  �� *TemplatedParent+$ LabelTextColor�����  �� *TemplatedParent+$ 	LabelText��� $	 PART_SearchIconBorder��$��2��$��Stretch=�$��Stretch=�8�� ._��� $ 
SearchIcon��$
��None=�$��15��$��15��$��Center=�$��Center=�$F��@pack://application:,,,/SearchTextBox;component/Images/search.png��$ Click to search���� $	 PART_SpecifySearchType��$��1��$��Stretch=�$��Stretch=�8�� ._��� $ SpecifySearchType��$
��None=�$��15��$��15��$��Center=�$��Center=�$G��Apack://application:,,,/SearchTextBox;component/Images/Key-Add.png��$ Choose section(s)���� $	 PART_PreviousItem��$��3��$��Stretch=�$��Stretch=�8�� ._��� $ PreviousIcon��$
��None=�$��15��$��15��$��Center=�$��Center=�$H��Bpack://application:,,,/SearchTextBox;component/Images/Previous.png��$ Previous keyword(s)�� P� $ 	LabelText�� �@J�IsMouseOver . . ��� $ 
LayoutGrid�� � �� �#F3F9F2��  �@�Cursor$ IBeam��P�  �@J�IsMouseOver .  . ��� $ 
LayoutGrid�� � �� �#DCEED9P�  �@J�IsKeyboardFocusWithin . . ��� 8   � ��P�  �@  HasText . . ��� $ 	LabelText�� � y�$ Hidden=�]�  ��  �@  HasText . ./��� $ 
SearchIcon�� � ��$E ?pack://application:,,,/SearchTextBox;component/Images/clear.png��