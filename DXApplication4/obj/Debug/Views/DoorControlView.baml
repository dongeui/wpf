   M S B A M L   `   `   `  ����I  EDXApplication4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DXApplication4.ViewModelsDXApplication4.ViewModels  5      /clr-namespace:DXApplication4DXApplication4  5
      /clr-namespace:DXApplication4DXApplication4  5      *    $DXApplication4.Views.DoorControlView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a] YDevExpress.Mvvm.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      :
ViewModels'clr-namespace:DXApplication4.ViewModels   5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      f bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	      3DXApplication4clr-namespace:DXApplication4   5
      *localclr-namespace:DXApplication4   5        � 	Resources  5      <  6DevExpress.Xpf.Core.DataSources.EntitySimpleDataSource   EntitySimpleDataSource4  .DevExpress.Xpf.Core.DataSources.DataSourceBase   ContextType   DXApplication4.ADTSC20   Path7  1DevExpress.Xpf.Core.DataSources.DesignDataManager   
DesignData8  2DevExpress.Xpf.Core.DataSources.DesignDataSettings   RowCount  EntitySimpleDataSource1��%�   &	        &	 f       5   
   "  6C   $ OC_OutputportInfo��6q    5        5      $ 5��6(   5        5   
   "  6D   $ UC_Organization��6r    5        5      $ 5��6(   5      5      .��5      (�  (� Stretch$ Uniform=�6   .��5    
   � .+�5!      &   DevExpress.Xpf.Core.DXTabControl  $
��auto��6   $��0,0,0,0q�6,   $
��auto��6=   .@�5"      #  DevExpress.Xpf.Core.DXTabItem  �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ 출입문 관리��6   .��5#      � 
������  � ColumnDefinitions 5$      �� 5%      $
��128* �6/   �� 5&      $��1437* �6/   .+�5(      &	   DevExpress.Xpf.Core.SimpleButton	  $��추가��6*   $��30��67   $��80��6C   $��277.578,342,1079,390q�6N   $��1��6�   ��6l   �� *AddDoorCommand+6�   	  5)      $��삭제��6*   $��30��67   $��80��6C   $��277.578,400,1079,332q�6N   $��1��6�   ��6l   �� *DeleteDoorCommand+6�   %
  DevExpress.Xpf.Grid.GridControl
  5+      |�.  )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6�   	   AutoGenerateColumns$	 AddNew=�6�   #
   EnableSmartColumnsGeneration
 . $
��Left=�6�   $	��702��6
  $��	30,30,0,0q�6  $	��Top=�6*  $	��200��6B  $	��400��6Q  $	��222��6a  $��2��6m     ItemsSource 6>   �� *SelectedDoorCollection+   SelectedItem 6m   �� *DeletedDoorSelected+ 
  View 5,      #  DevExpress.Xpf.Grid.TableView  5-   "   |�.  !   ShowCheckBoxSelectorColumn . &   DevExpress.Xpf.Grid.DataViewBase   NavigationStyle$	 Row=�6e   $��0,0,-2,0q�6|      UseIndicatorForSelection .  6�   5/      
  51       
  
GroupCount$ 3��6+   |�.  $ MultipleRow=�6�   $	 AddNew=�6�   
 . $
��Left=�6   $��386.578,30,0,0q�6;  $	��Top=�6S  $	��390��6k  $	��400��6z  $	��400��6�  $	��702��6�  $
��1032��6�  $��1��6�   6L   �� *Data+ �� Source# [     SelectedItems 6�   �� *DoorSelected+ 52        53   "   |�.   . $	 Row=�6d   $��
0,0,-634,0q�6z    .  6�   55      57      58        5=      $ 조직 관리��6   $��22��6.   $��Bottom=�6:   .��5>      � 
������ .+�5?      	  $��등록��6*   $��20��68   $��70��6D   $��30,67,1474,683q�6P   ��6h   �� *AddGroupCommand+��6�   �� *Text+ �� ElementName$ inputGroupName��	  5@      $��제거��6*   $��20��68   $��70��6D   $��264,67,1240,683q�6P   ��6i   �� *DeleteGroupCommand+	  5A      $��추가��6*   $��20��68   $��70��6D   $��654,308,850,442q�6P   ��6i   �� *AddGroupListCommand+	  5B      $��삭제��6*   $��20��68   $��70��6D   $��654,362,850,388q�6P   ��6i   �� *DeleteGroupListCommand+�� 5C      -   5        $��inputGroupName��5C   "   $
��Left=�68   $��23��6S   $��	30,30,0,0q�6_    �� TextWrapping$
 Wrap=�6r   $��등록할 그룹명��6�   $	��Top=�6�   $	��170��6�   
  5E      -   5        |�. $	 Row=�5E   �   $	 AddNew=�6  
 . $
��Left=�6M  $��
30,100,0,0q�6h  $	��Top=�6|   6o   �� *SelectedGroupCollection+   ColumnsSource 6�   �� *SelectedGroupCollection+ 6�   �� *GroupSelected+ 5F        5G   "   -   5        $��Group��5G   u    .    AllowEditing .     ShowTotalSummary .    	AutoWidth .  $	��302��6�   $	��605��6�   $��Bottom=�6�      
FocusedRow 61   �� *
FocusGroup+6�   5I      
  5K      |�.  $	 Row=�6�   $	 AddNew=�6�   
 . $
��Left=�6�   $��350,30,0,00q�6�   $	��700��6
  $	��Top=�6   6<   �� *ShowDicValues+ 6b   �� *	DeleteDic+ 5L        5M   "   $	 Row=�60    .  .  $	��268��6}   $	��698��6�   $��Bottom=�6�   5O      
  5Q      |�.  $ MultipleRow=�6�   $	 AddNew=�6�   
 . $
��Left=�6   $��
758,30,0,0q�6;  $	��Top=�6O  $	��700��6h  $	��762��6u   6<   �� *Data+# [  6�   �� *SelectedGroupInListCollection+ 5R        5S   "   $	 Row=�61    . 6H   5U      5W      5X      5Y      5[      5\      5]      